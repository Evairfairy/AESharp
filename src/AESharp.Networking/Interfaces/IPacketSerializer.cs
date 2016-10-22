using System;
using System.IO;
using System.Text;

namespace AESharp.Networking.Interfaces
{
    [Obsolete( "Reflection packet handling will be removed soon" )]
    public interface IPacketSerializer
    {
        void SerializePacket( IPacket packet, Stream output, Encoding encoding );
        void SerializePacket( object packet, Stream output, Encoding encoding );
        T DeserializePacket< T >( Stream input, Encoding encoding ) where T : IPacket;
        object DeserializePacket( Type type, Stream input, Encoding encoding );
    }
}