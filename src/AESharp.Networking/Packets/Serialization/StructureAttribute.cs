using System;

namespace AESharp.Networking.Packets.Serialization
{
    public enum MemberSerialization
    {
        OptIn,
        OptOut
    }

    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct )]
    public sealed class StructureAttribute : Attribute
    {
        public StructureAttribute()
        {
            this.IncludeFields = true;
            this.IncludeProperties = true;
            this.MemberSerialization = MemberSerialization.OptIn;
        }

        public bool IncludeProperties { get; set; }
        public bool IncludeFields { get; set; }
        public MemberSerialization MemberSerialization { get; set; }
    }
}