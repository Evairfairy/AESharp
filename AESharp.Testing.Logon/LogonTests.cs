using System;
using System.Net.Sockets;
using System.Threading;
using Xunit;

namespace AESharp.Testing.Logon
{
    public class LogonTests
    {
        [Fact]
        public void AESharpTempMiscProtocolTest()
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 16000);
            Assert.True(client.Connected);

            uint opcode = 1000;
            uint length = 0;
            long sender = 16000;
            long target = 32000;

            byte[] buffer = new byte[24];

            Array.Copy(BitConverter.GetBytes(opcode), buffer, 4);
            Array.Copy(BitConverter.GetBytes(length), 0, buffer, 4, 4);
            Array.Copy(BitConverter.GetBytes(sender), 0, buffer, 8, 8);
            Array.Copy(BitConverter.GetBytes(target), 0, buffer, 16, 8);

            client.GetStream().Write(buffer, 0, buffer.Length);

            Thread.Sleep(1000);

            //byte[] readBuffer = new byte[4];
            //int bytesRead = client.GetStream().Read( readBuffer, 0, readBuffer.Length );

            //Assert.AreEqual( bytesRead, 4 );

            //uint newOpcode = BitConverter.ToUInt32( readBuffer, 0 );

            //Assert.AreEqual( newOpcode, opcode * opcode );
        }
    }
}