using System;
using System.Net;
using System.Text;
using AESharp.Interop;
using AESharp.Networking;
using AESharp.Networking.Events;

namespace AESharp.Logon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Attempting interop");
            
            InteropExample.number_fn square = Square;

            Console.WriteLine($"4 squared = {Square(4)}");

            Console.ReadLine();

            AETcpServer server = new AETcpServer(IPAddress.Any, 3724);
            server.StartListening();

            server.ReceiveData += ServerOnReceiveData;

            Console.ReadLine();
        }

        private static int Square(int n)
        {
            return n * n;
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
