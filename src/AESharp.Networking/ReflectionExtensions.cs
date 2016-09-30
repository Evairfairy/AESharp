using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace AESharp.Networking
{
    internal static class ReflectionExtensions
    {
        public static bool Inherits( this Type self, Type type )
        {
            var baseType = self.GetTypeInfo().BaseType;
            while( baseType != null )
            {
                if( baseType == type )
                    return true;

                baseType = baseType.GetTypeInfo().BaseType;
            }

            return false;
        } 
    }
}
