using DictionaryInActions.src;

namespace DictionaryInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var md = new MultiValueDictionary<int, int>
            {
                { 1,  1 },
                { 1, 12 },
                { 1, 13 },
                { 2,  2 },
                { 2, 21 },
                { 3,  3 },
                { 4,  4 },
                { 4, 41 },
                { 1,  1 }
            };

            //List<KeyValuePair<int, int>>  f = md.Flatten();
            //foreach(var kv in f)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", kv.Key, kv.Value);
            //}

            using (IEnumerator<KeyValuePair<int, int>> empEnumerator = md.GetEnumerator())
            {
                while (empEnumerator.MoveNext())
                {
                    Console.WriteLine("Key: {0}, Value: {1}", empEnumerator.Current.Key, empEnumerator.Current.Value);
                }
            }

            //Console.WriteLine("Dictionary size before Clear() call: {0}", md.Flatten().Count);
            //List<KeyValuePair<int, int>> f = md.Flatten();
            //foreach (var kv in f)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", kv.Key, kv.Value);
            //}

            //md.Clear();
            //Console.WriteLine("Dictionary size after Clear() call: {0}", md.Flatten().Count);

            //AlienLanguageOps.Test_IsAlienSorted();
        }
    }
}