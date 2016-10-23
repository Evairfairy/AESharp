using System;
using System.Reflection;

namespace AESharp.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool Inherits( this Type self, Type type )
        {
            Type baseType = self.GetTypeInfo().BaseType;
            while ( baseType != null )
            {
                if ( baseType == type )
                {
                    return true;
                }

                baseType = baseType.GetTypeInfo().BaseType;
            }

            return false;
        }

        public static bool Implements( this Type self, Type type )
        {
            if ( !type.GetTypeInfo().IsInterface )
            {
                return false;
            }

            return type.IsAssignableFrom( self );
        }

        public static bool Implements<T>( this Type self )
                => self.Implements( typeof( T ) );
    }
}