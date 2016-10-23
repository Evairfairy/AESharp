using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AESharp.Interop;

namespace AESharp.Logon
{
    public class TempInteropTests
    {
        public static void RunInteropTests()
        {
            Console.WriteLine( "Attempting interop" );

            TestGetNumberFunc();
            TestOperateOn();
            TestGetPerson();
            TestGetLastName();
            TestGetBytes();
            TestGetNumber();
        }

        private static int Square( int n )
        {
            return n * n;
        }

        private static void TestGetNumberFunc()
        {
            const int number = 10;
            InteropExample.numberfn_t cube = InteropExample.get_number_func();
            Console.WriteLine( $"{number} cubed is {cube( 10 )}" );
        }

        private static void TestOperateOn()
        {
            const int number = 10;
            int result = InteropExample.operate_on( number, Square );
            Console.WriteLine( $"{number} squared is {result}" );
        }

        private static void TestGetPerson()
        {
            IntPtr ptr = InteropExample.get_person();
            Person person = Marshal.PtrToStructure<Person>( ptr );
            Console.WriteLine( $"{person.firstname} {person.lastname} is {person.age} years old" );
        }

        private static void TestGetLastName()
        {
            Person person = new Person( "Tony", "Ellis", 22 );
            IntPtr ptr = Marshal.AllocHGlobal( Marshal.SizeOf<Person>() );
            Marshal.StructureToPtr( person, ptr, false );
            string name = InteropExample.get_last_name( ptr );
            Console.WriteLine( $"{person.firstname}'s last name is {name}" );
        }

        private static void TestGetBytes()
        {
            const int number = 5;
            IntPtr ptr = InteropExample.get_bytes( number );
            byte[] buf = new byte[sizeof( int )];
            Marshal.Copy( ptr, buf, 0, buf.Length );
            IEnumerable<string> hex = buf.Select( b => $"0x{b:X2}" );
            Console.WriteLine( $"{number} == [ {string.Join( ", ", hex )} ]" );
        }

        private static void TestGetNumber()
        {
            const int number = 5;
            byte[] buf = BitConverter.GetBytes( number );
            IEnumerable<string> hex = buf.Select( b => $"0x{b:X2}" );
            IntPtr ptr = Marshal.AllocHGlobal( sizeof( int ) );
            Marshal.Copy( buf, 0, ptr, buf.Length );
            int result = InteropExample.get_number( ptr );
            Console.WriteLine( $"[ {string.Join( ", ", hex )}] == {result}" );
        }
    }
}
