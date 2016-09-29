using System.Linq;
using System.Text;

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