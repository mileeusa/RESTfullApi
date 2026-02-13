using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    public static class MultiValueDictionaryExtensions
    {
        // Creates a deep copy
        public static IMultiValueDictionary<TKey, TValue> Clone<TKey, TValue>(
            this IMultiValueDictionary<TKey, TValue> source) where TKey : notnull
        {
            var result = new MultiValueDictionary<TKey, TValue>();

            foreach (var (k, v) in source)
                result.Add(k, v);

            return result;
        }

        // A ∪ B
        public static IMultiValueDictionary<TKey, TValue> Union<TKey, TValue>(
            this IMultiValueDictionary<TKey, TValue> a,
            IMultiValueDictionary<TKey, TValue> b) where TKey : notnull
        {
            var result = a.Clone();

            foreach (var (k, v) in b)
                result.Add(k, v);

            return result;
        }

        // A ∩ B
        public static IMultiValueDictionary<TKey, TValue> Intersect<TKey, TValue>(
            this IMultiValueDictionary<TKey, TValue> a,
            IMultiValueDictionary<TKey, TValue> b) where TKey : notnull
        {
            var result = new MultiValueDictionary<TKey, TValue>();

            var bLookup = b.GroupBy(kvp => kvp.Key)
                           .ToDictionary(g => g.Key, g => g.Select(x => x.Value).ToHashSet());

            foreach (var (k, v) in a)
            {
                if (bLookup.TryGetValue(k, out var valueSet) && valueSet.Contains(v))
                {
                    result.Add(k, v);
                }
            }

            return result;
        }

        // A \ B
        public static IMultiValueDictionary<TKey, TValue> Except<TKey, TValue>(
            this IMultiValueDictionary<TKey, TValue> a,
            IMultiValueDictionary<TKey, TValue> b) where TKey : notnull
        {
            var result = new MultiValueDictionary<TKey, TValue>();

            var bLookup = b.GroupBy(kvp => kvp.Key)
                           .ToDictionary(g => g.Key, g => g.Select(x => x.Value).ToHashSet());

            foreach (var (k, v) in a)
            {
                if (!bLookup.TryGetValue(k, out var valueSet) || !valueSet.Contains(v))
                    result.Add(k, v);
            }

            return result;
        }

        // (A ∪ B) − (A ∩ B)
        public static IMultiValueDictionary<TKey, TValue> SymmetricExcept<TKey, TValue>(
            this IMultiValueDictionary<TKey, TValue> a,
            IMultiValueDictionary<TKey, TValue> b) where TKey : notnull
        {
            var union = a.Union(b);
            var intersection = a.Intersect(b);

            return union.Except(intersection);
        }
    }
}
