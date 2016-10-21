using System;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public sealed class SerializeAttribute : Attribute
    {
    }

    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public sealed class SerializeIgnore : Attribute
    {
    }
}