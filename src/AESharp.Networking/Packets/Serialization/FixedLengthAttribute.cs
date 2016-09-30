using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
    public sealed class FixedLengthAttribute : Attribute
    {
        public int Length { get; }

        public FixedLengthAttribute( int length )
        {
            this.Length = length;
        }
    }
}
