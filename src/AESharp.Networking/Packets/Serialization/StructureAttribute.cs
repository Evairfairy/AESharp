using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization
{
    public enum MemberSerialization
    {
        OptIn,
        OptOut,
    }

    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false )]
    public sealed class StructureAttribute : Attribute
    {
        public bool IncludeProperties { get; set; }
        public bool IncludeFields { get; set; }
        public MemberSerialization MemberSerialization { get; set; }

        public StructureAttribute()
        {
            this.IncludeFields = true;
            this.IncludeProperties = true;
            this.MemberSerialization = MemberSerialization.OptIn;
        }
    }
}
