using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AESharp.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Flip( this string s )
        {
            return new string( s.Reverse().ToArray() );
        }

        public static byte[] ByteRepresentationToByteArray( this string s )
        {
            IEnumerable<string> byteStrings = s.Chunks( 2 );
            return byteStrings.Select( x => byte.Parse( x, NumberStyles.AllowHexSpecifier ) ).ToArray();
        }

        public static IEnumerable<string> Chunks( this string source, int chunkSize )
        {
            int len = source.Length;
            for ( int i = 0; i < len; i += chunkSize )
            {
                yield return source.Substring( i, Math.Min( chunkSize, len - i ) );
            }
        }
    }
}