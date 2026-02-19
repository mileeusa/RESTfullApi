using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    //[Serializable, StructLayout(LayoutKind.Sequential)]
    //public struct KeyValuePair<TKey, TValue>
    //{
    //    private TKey key;
    //    private TValue value;
    //    public KeyValuePair(TKey key, TValue value);
    //    public TKey Key { get; }
    //    public TValue Value { get; }
    //    public override string ToString();
    //}

    public class KeyValuePairOps
    {
        public static KeyValuePair<TKey, TValue> CreateKeyValuePair<TKey, TValue>(TKey key, TValue value)
        {
            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}
