using System.Runtime.InteropServices;

namespace AESharp.Interop
{
    public static class InteropExample
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int number_fn(int n);

        [DllImport("./cpplogon.exe")]
        public static extern int invoke_me(int n, [MarshalAs(UnmanagedType.FunctionPtr)] number_fn fn);
    }
}