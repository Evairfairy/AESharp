using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
    public sealed class SerializeAttribute : Attribute { }

    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public sealed class SerializeIgnore : Attribute { }
}
