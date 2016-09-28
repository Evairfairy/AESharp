using System;
using System.Net;
using System.Linq;
using System.Text;
using AESharp.Interop;
using AESharp.Networking;
using AESharp.Networking.Events;
using System.Runtime.InteropServices;

namespace AESharp.Logon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Attempting interop");

            TestGetNumberFunc();
            TestOperateOn();
            TestGetPerson();
            TestGetLastName();
            TestGetBytes();
            TestGetNumber();

            return;

            //AETcpServer server = new AETcpServer(IPAddress.Any, 3724);
            //server.StartListening();

            //server.ReceiveData += ServerOnReceiveData;

            //Console.ReadLine();
        }

        private static int Square(int n)
        {
            return n * n;
        }

        private static void TestGetNumberFunc()
        {
            const int number = 10;
            var cube = InteropExample.get_number_func();
            Console.WriteLine( $"{number} cubed is {cube( 10 )}" );
        }

        private static void TestOperateOn()
        {
            const int number = 10;
            var result = InteropExample.operate_on( number, Square );
            Console.WriteLine( $"{number} squared is {result}" );
        }

        private static void TestGetPerson()
        {
            var ptr = InteropExample.get_person();
            var person = Marshal.PtrToStructure<Person>( ptr );
            Console.WriteLine( $"{person.firstname} {person.lastname} is {person.age} years old" );
        }

        private static void TestGetLastName()
        {
            var person = new Person( "Tony", "Ellis", 22 );
            IntPtr ptr = Marshal.AllocHGlobal( Marshal.SizeOf<Person>() );
            Marshal.StructureToPtr( person, ptr, false );
            var name = InteropExample.get_last_name( ptr );
            Console.WriteLine( $"{person.firstname}'s last name is {name}" );
        }

        private static void TestGetBytes()
        {
            const int number = 5;
            var ptr = InteropExample.get_bytes( number );
            var buf = new byte[sizeof( int )];
            Marshal.Copy( ptr, buf, 0, buf.Length );
            var hex = buf.Select( b => $"0x{b:X2}" );
            Console.WriteLine( $"{number} == [ {String.Join( ", ", hex ) } ]" );
        }

        private static void TestGetNumber()
        {
            const int number = 5;
            var buf = BitConverter.GetBytes( number );
            var hex = buf.Select( b => $"0x{b:X2}" );
            var ptr = Marshal.AllocHGlobal( sizeof( int ) );
            Marshal.Copy( buf, 0, ptr, buf.Length );
            var result = InteropExample.get_number( ptr );
            Console.WriteLine( $"[ {String.Join( ", ", hex ) }] == {result}" );
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
