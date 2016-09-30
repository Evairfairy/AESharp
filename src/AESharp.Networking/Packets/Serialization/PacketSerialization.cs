using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace AESharp.Networking.Packets.Serialization
{
    public static class PacketSerialization
    {
        private delegate object ObjectDeserializer( Type type, Stream input, Encoding encoding );
        private delegate void ObjectSerializer( Type type, object instance, Stream output, Encoding encoding );

        private static readonly object SyncRoot;
        private static readonly Dictionary<Type, ObjectDeserializer> DeserializerCache;
        private static readonly Dictionary<Type, ObjectSerializer> SerializerCache;

        static PacketSerialization()
        {
            SyncRoot = new object();
            DeserializerCache = new Dictionary<Type, ObjectDeserializer>();
            SerializerCache = new Dictionary<Type, ObjectSerializer>();
        }

        public static void SerializeObject( object instance, Stream output, Encoding encoding = null )
        {
            var type = instance.GetType();
            var serialize = BuildObjectSerializerFor( type );
            serialize( type, instance, output, encoding ?? Encoding.UTF8 );
        }

        public static T DeserializeObject<T>( Stream input, Encoding encoding = null )
            => (T)DeserializeObject( typeof( T ), input, encoding );

        public static object DeserializeObject( Type type, Stream input, Encoding encoding = null )
        {
            var deserialize = BuildObjectDeserializerFor( type );
            return deserialize( type, input, encoding ?? Encoding.UTF8 );
        }

        // Allow objects to be caches ahead of time
        public static void CacheObjects( params Type[] types )
        {
            foreach( var type in types )
            {
                BuildObjectDeserializerFor( type );
                BuildObjectSerializerFor( type );
            }
        }

        // Perform one-time only reflection to load type and attribute information
        // and create a delegate that will read streams and set fields/properties
        private static ObjectDeserializer BuildObjectDeserializerFor( Type type )
        {
            ObjectDeserializer deserializer;
            if( DeserializerCache.TryGetValue( type, out deserializer ) )
                return deserializer;

            bool empty;
            var members = ReflectObject( type, out empty );
            deserializer = empty ? MakeDummyDeserializer( type ) : MakeDeserializer( members );
            DeserializerCache[type] = deserializer;

            return deserializer;
        }

        private static ObjectSerializer BuildObjectSerializerFor( Type type )
        {
            ObjectSerializer serializer;
            if( SerializerCache.TryGetValue( type, out serializer ) )
                return serializer;

            bool empty;
            var members = ReflectObject( type, out empty );
            serializer = empty ? MakeDummySerializer() : MakeSerializer( members );
            SerializerCache[type] = serializer;

            return serializer;
        }

        private static IEnumerable<ReflectedMember> ReflectObject( Type type, out bool empty )
        {
            const BindingFlags InstanceFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            var typeInfo = type.GetTypeInfo();
            var structAttr = typeInfo.GetCustomAttribute<StructureAttribute>();
            var includeProperties = structAttr?.IncludeProperties ?? true;
            var includeFields = structAttr?.IncludeFields ?? true;
            var memberSerialization = structAttr?.MemberSerialization ?? MemberSerialization.OptOut;

            if( !includeProperties && !includeFields )
            {
                empty = true;
                return null;
            }

            IEnumerable<MemberInfo> members = null;

            if( includeFields )
                members = typeInfo.GetFields( InstanceFlags ).Cast<MemberInfo>();

            if( includeProperties )
            {
                var properties = typeInfo.GetProperties( InstanceFlags ).Cast<MemberInfo>();

                if( members == null )
                    members = properties;
                else
                    members = members.Concat( properties );
            }

            Func<MemberInfo, bool> serializationModeFilter = delegate ( MemberInfo m )
            {
                if( memberSerialization == MemberSerialization.OptIn )
                    return m.GetCustomAttribute<SerializeAttribute>() != null;
                else
                    return m.GetCustomAttribute<SerializeIgnore>() == null;
            };

            Func<MemberInfo, bool> compilerGeneratedFilter = delegate ( MemberInfo m )
            {
                return m.GetCustomAttribute<CompilerGeneratedAttribute>() == null;
            };

            Func<MemberInfo, bool> hasSetterFilter = delegate ( MemberInfo m )
            {
                var property = m as PropertyInfo;
                if( property == null )
                    return true;
                else
                    return property.GetSetMethod( true ) != null;
            };

            empty = false;
            return members.Where( compilerGeneratedFilter )
                          .Where( hasSetterFilter )
                          .Where( serializationModeFilter )
                          .Select( m => new ReflectedMember( m ) );
        }

        private static ObjectDeserializer MakeDummyDeserializer( Type type )
            => ( t, i, e ) => Activator.CreateInstance( type, true );

        private static ObjectSerializer MakeDummySerializer()
            => ( t, i, o, e ) => { };

        private static ObjectDeserializer MakeDeserializer( IEnumerable<ReflectedMember> members )
        {
            return delegate ( Type type, Stream input, Encoding encoding )
            {
                var instance = Activator.CreateInstance( type, true );

                using( var reader = new BinaryReader( input, encoding, true ) )
                {
                    foreach( var member in members )
                    {
                        var currentValue = member.GetValue( instance );
                        var value = member.Converter.Read( reader, instance, member.Type, currentValue, member.Length );
                        foreach( var transform in member.Transformers )
                            value = transform( value );

                        member.SetValue( value, instance);
                    }
                }

                return instance;
            };
        }

        private static ObjectSerializer MakeSerializer( IEnumerable<ReflectedMember> members )
        {
            return delegate ( Type type, object instance, Stream output, Encoding encoding )
            {
                using( var writer = new BinaryWriter( output, encoding, true ) )
                {
                    foreach( var member in members )
                    {
                        var value = member.GetValue( instance );
                        foreach( var transform in member.Transformers )
                            value = transform( value );

                        member.Converter.Write( writer, instance, type, value, member.Length );
                    }
                }
            };
        }
    }
}
