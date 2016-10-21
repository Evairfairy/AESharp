using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AESharp.Core.Interfaces
{
    public interface IPacketSerializer
    {
        void SerializePacket( IPacket packet, Stream output, Encoding encoding );
        void SerializePacket( object packet, Stream output, Encoding encoding );
        T DeserializePacket< T >( Stream input, Encoding encoding ) where T : IPacket;
        object DeserializePacket( Type type, Stream input, Encoding encoding );
    }
}