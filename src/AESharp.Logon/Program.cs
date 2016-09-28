using System;
using System.Net;
using System.Text;
using AESharp.Networking;
using AESharp.Networking.Events;

namespace AESharp.Logon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AETcpServer server = new AETcpServer(IPAddress.Any, 3724);
            server.StartListening();

            server.ReceiveData += ServerOnReceiveData;

            Console.ReadLine();
        }

        private static void ServerOnReceiveData(object sender, NetworkEventArgs networkEventArgs)
        {
            string dataToString = Encoding.UTF8.GetString(networkEventArgs.Data);

            if (dataToString.Contains("DANY"))
            {
                networkEventArgs.Cancel = true;
            }
        }
    }
}
