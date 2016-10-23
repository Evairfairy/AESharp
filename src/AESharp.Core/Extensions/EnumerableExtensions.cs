using System;
using System.Collections.Generic;
using System.Linq;

namespace AESharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunks<T>( this IEnumerable<T> enumerable, int chunkSize )
        {
            int len = enumerable.Count();
            for ( int i = 0; i < len; i += chunkSize )
            {
                yield return enumerable.Skip( i ).Take( Math.Min( chunkSize, len - i ) );
            }
        }
    }
}