using System;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public sealed class FixedLengthAttribute : Attribute
    {
        public FixedLengthAttribute( int length )
        {
            this.Length = length;
        }

        public int Length { get; }
    }
}