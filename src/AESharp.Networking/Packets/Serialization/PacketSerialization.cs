using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using AESharp.Core.Interfaces;

namespace AESharp.Networking.Packets.Serialization
{
    public class PacketSerialization : IPacketSerializer
    {
        private readonly Dictionary<Type, ObjectDeserializer> _deserializerCache;
        private readonly object _objectCacheLock;
        private readonly Dictionary<Type, ObjectSerializer> _serializerCache;

        public PacketSerialization()
        {
            this._objectCacheLock = new object();
            this._deserializerCache = new Dictionary<Type, ObjectDeserializer>();
            this._serializerCache = new Dictionary<Type, ObjectSerializer>();
        }

        private void SerializeObject( object instance, Stream output, Encoding encoding = null )
        {
            Type type = instance.GetType();
            ObjectSerializer serialize = this.BuildObjectSerializerFor( type );
            serialize( type, instance, output, encoding ?? Encoding.UTF8 );
        }

        private T DeserializeObject< T >( Stream input, Encoding encoding = null )
            => (T) this.DeserializeObject( typeof( T ), input, encoding );

        private object DeserializeObject( Type type, Stream input, Encoding encoding = null )
        {
            ObjectDeserializer deserialize = this.BuildObjectDeserializerFor( type );
            return deserialize( type, input, encoding ?? Encoding.UTF8 );
        }

        // Allow objects to be caches ahead of time
        public void CacheObjects( params Type[] types )
        {
            foreach ( Type type in types )
            {
                lock ( this._objectCacheLock )
                {
                    this.BuildObjectDeserializerFor( type );
                    this.BuildObjectSerializerFor( type );
                }
            }
        }

        // Perform one-time only reflection to load type and attribute information
        // and create a delegate that will read streams and set fields/properties
        private ObjectDeserializer BuildObjectDeserializerFor( Type type )
        {
            lock ( this._deserializerCache )
            {
                ObjectDeserializer deserializer;
                if ( this._deserializerCache.TryGetValue( type, out deserializer ) )
                {
                    return deserializer;
                }

                bool empty;
                IEnumerable<ReflectedMember> members = this.ReflectObject( type, out empty );
                deserializer = empty ? this.MakeDummyDeserializer( type ) : this.MakeDeserializer( members );
                this._deserializerCache[type] = deserializer;

                return deserializer;
            }
        }

        private ObjectSerializer BuildObjectSerializerFor( Type type )
        {
            lock ( this._serializerCache )
            {
                ObjectSerializer serializer;
                if ( this._serializerCache.TryGetValue( type, out serializer ) )
                {
                    return serializer;
                }

                bool empty;
                IEnumerable<ReflectedMember> members = this.ReflectObject( type, out empty );
                serializer = empty ? this.MakeDummySerializer() : this.MakeSerializer( members );
                this._serializerCache[type] = serializer;

                return serializer;
            }
        }

        private IEnumerable<ReflectedMember> ReflectObject( Type type, out bool empty )
        {
            const BindingFlags instanceFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            TypeInfo typeInfo = type.GetTypeInfo();
            StructureAttribute structAttr = typeInfo.GetCustomAttribute<StructureAttribute>();
            bool includeProperties = structAttr?.IncludeProperties ?? true;
            bool includeFields = structAttr?.IncludeFields ?? true;
            MemberSerialization memberSerialization = structAttr?.MemberSerialization ?? MemberSerialization.OptOut;

            if ( !includeProperties && !includeFields )
            {
                empty = true;
                return null;
            }

            IEnumerable<MemberInfo> members = null;

            if ( includeFields )
            {
                members = typeInfo.GetFields( instanceFlags );
            }

            if ( includeProperties )
            {
                IEnumerable<MemberInfo> properties = typeInfo.GetProperties( instanceFlags );

                members = members == null ? properties : members.Concat( properties );
            }

            Func<MemberInfo, bool> serializationModeFilter = delegate( MemberInfo m )
            {
                if ( memberSerialization == MemberSerialization.OptIn )
                {
                    return m.GetCustomAttribute<SerializeAttribute>() != null;
                }
                return m.GetCustomAttribute<SerializeIgnore>() == null;
            };

            Func<MemberInfo, bool> compilerGeneratedFilter =
                m => m.GetCustomAttribute<CompilerGeneratedAttribute>() == null;

            Func<MemberInfo, bool> hasSetterFilter = delegate( MemberInfo m )
            {
                PropertyInfo property = m as PropertyInfo;
                if ( property == null )
                {
                    return true;
                }
                return property.GetSetMethod( true ) != null;
            };

            empty = false;
            return members.Where( compilerGeneratedFilter )
                .Where( hasSetterFilter )
                .Where( serializationModeFilter )
                .Select( m => new ReflectedMember( m ) );
        }

        private ObjectDeserializer MakeDummyDeserializer( Type type )
            => ( t, i, e ) => Activator.CreateInstance( type, true );

        private ObjectSerializer MakeDummySerializer()
            => ( t, i, o, e ) => { };

        private ObjectDeserializer MakeDeserializer( IEnumerable<ReflectedMember> members )
        {
            return delegate( Type type, Stream input, Encoding encoding )
            {
                object instance = Activator.CreateInstance( type, true );

                using ( BinaryReader reader = new BinaryReader( input, encoding, true ) )
                {
                    foreach ( ReflectedMember member in members )
                    {
                        IEnumerable<TransformerAttribute> readTransformers =
                            member.Transformers.Where( t => t.SerializationMode.HasFlag( SerializationMode.Read ) );
                        object currentValue = member.GetValue( instance );
                        object value = member.Converter.Read( reader, instance, member.Type, currentValue, member.Length );
                        foreach ( TransformerAttribute transformer in readTransformers )
                        {
                            value = transformer.Transform( value, member.Length );
                        }

                        member.SetValue( instance, value );
                    }
                }

                return instance;
            };
        }

        private ObjectSerializer MakeSerializer( IEnumerable<ReflectedMember> members )
        {
            return delegate( Type type, object instance, Stream output, Encoding encoding )
            {
                using ( BinaryWriter writer = new BinaryWriter( output, encoding, true ) )
                {
                    foreach ( ReflectedMember member in members )
                    {
                        IEnumerable<TransformerAttribute> writeTransformers =
                            member.Transformers.Where( t => t.SerializationMode.HasFlag( SerializationMode.Write ) );
                        object value = member.GetValue( instance );
                        foreach ( TransformerAttribute transformer in writeTransformers )
                        {
                            value = transformer.Transform( value, member.Length );
                        }

                        member.Converter.Write( writer, instance, type, value, member.Length );
                    }
                }
            };
        }

        private delegate object ObjectDeserializer( Type type, Stream input, Encoding encoding );

        private delegate void ObjectSerializer( Type type, object instance, Stream output, Encoding encoding );

        public void SerializePacket( IPacket packet, Stream output, Encoding encoding )
        {
            this.SerializeObject( packet, output, encoding );
        }

        public T DeserializePacket< T >( Stream input, Encoding encoding ) where T : IPacket
        {
            return this.DeserializeObject<T>( input, encoding );
        }
    }
}