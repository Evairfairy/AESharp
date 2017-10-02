using System.Collections.Generic;

namespace AESharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> InChunksOf<T>( this IEnumerable<T> enumerable, int chunkSize )
        {
            using ( IEnumerator<T> enumerator = enumerable.GetEnumerator() )
            {
                while ( enumerator.MoveNext() )
                {
                    yield return enumerator.SelectChunk( chunkSize );
                }
            }
        }

        public static string Join<T>( this IEnumerable<T> collection, string delim )
            => string.Join( delim, collection );

        private static IEnumerable<T> SelectChunk<T>( this IEnumerator<T> enumerator, int chunkSize )
        {
            yield return enumerator.Current;

            int i = -1;
            while ( ( ++i < chunkSize ) && enumerator.MoveNext() )
            {
                yield return enumerator.Current;
            }
        }
    }
}