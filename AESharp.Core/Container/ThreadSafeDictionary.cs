using System.Collections.Generic;

namespace AESharp.Core.Container
{
    public class ThreadSafeDictionary<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> InternalDictionary = new Dictionary<TKey, TValue>();

        public void Add( TKey key, TValue value )
        {
            lock ( this.InternalDictionary )
            {
                this.InternalDictionary.Add( key, value );
            }
        }

        public bool ContainsKey( TKey key )
        {
            lock ( this.InternalDictionary )
            {
                return this.InternalDictionary.ContainsKey( key );
            }
        }

        public bool ContainsValue( TValue value )
        {
            lock ( this.InternalDictionary )
            {
                return this.InternalDictionary.ContainsValue( value );
            }
        }

        public TValue Get( TKey key )
        {
            lock ( this.InternalDictionary )
            {
                return this.InternalDictionary[key];
            }
        }

        public void ReplaceOrAdd( TKey key, TValue value )
        {
            lock ( this.InternalDictionary )
            {
                if ( this.InternalDictionary.ContainsKey( key ) )
                {
                    this.InternalDictionary.Remove( key );
                }

                this.InternalDictionary.Add( key, value );
            }
        }
    }
}