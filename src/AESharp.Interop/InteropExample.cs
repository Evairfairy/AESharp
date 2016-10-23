using System;
using System.Runtime.InteropServices;

namespace AESharp.Interop
{
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi )]
    public struct Person
    {
        public string firstname;
        public string lastname;
        public int age;

        public Person( string first, string last, int age )
        {
            this.firstname = first;
            this.lastname = last;
            this.age = age;
        }
    }

    public static class InteropExample
    {
        [UnmanagedFunctionPointer( CallingConvention.Cdecl )]
        public delegate int numberfn_t( int n );

        [DllImport( "InteropTest.dll" )]
        [return: MarshalAs( UnmanagedType.FunctionPtr )]
        public static extern numberfn_t get_number_func();

        [DllImport( "InteropTest.dll" )]
        public static extern int operate_on( int n, [MarshalAs( UnmanagedType.FunctionPtr )] numberfn_t fn );

        [DllImport( "InteropTest.dll" )]
        public static extern IntPtr get_person();

        [DllImport( "InteropTest.dll" )]
        public static extern string get_last_name( IntPtr ptr );

        [DllImport( "InteropTest.dll" )]
        public static extern IntPtr get_bytes( int n );

        [DllImport( "InteropTest.dll" )]
        public static extern int get_number( IntPtr buf );
    }
}
