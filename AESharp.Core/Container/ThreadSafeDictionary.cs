using System.Collections.Generic;

namespace AESharp.Core.Container
{
    public class ThreadSafeDictionary<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> InternalDictionary = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            lock (InternalDictionary)
                InternalDictionary.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            lock (InternalDictionary)
                return InternalDictionary.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            lock (InternalDictionary)
                return InternalDictionary.ContainsValue(value);
        }

        public TValue Get(TKey key)
        {
            lock (InternalDictionary)
                return InternalDictionary[key];
        }

        public void ReplaceOrAdd(TKey key, TValue value)
        {
            lock (InternalDictionary)
            {
                if (InternalDictionary.ContainsKey(key))
                    InternalDictionary.Remove(key);

                InternalDictionary.Add(key, value);
            }
        }
    }
}