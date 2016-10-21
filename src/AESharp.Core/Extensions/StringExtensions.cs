using System.Linq;

namespace AESharp.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Flip( this string s )
        {
            return new string( s.Reverse().ToArray() );
        }
    }
}