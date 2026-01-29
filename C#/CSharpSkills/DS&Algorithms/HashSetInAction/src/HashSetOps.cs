using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HashSetInAction.src
{
    public class ListNode
    {
        public int Val;
        public ListNode Next;
        public ListNode(int val) { Val = val; }
    }

    public class HashSetOps
    {
        public static int[] RemoveDuplicates(int[] nums)
        {
            return new HashSet<int>(nums).ToArray();
        }

        public static bool SameDistinctElements(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = [.. nums1];
            HashSet<int> set2 = [.. nums2];
            return set1.SetEquals(set2);
        }

        public static bool HasUniqueChars(string s)
        {
            HashSet<char> set = [.. s.ToCharArray()];

            //foreach (char c in s)
            //{
            //    if (set.Contains(c))
            //    {
            //        return false;
            //    }
            //    set.Add(c);
            //}
            //return true;

            return set.Count == s.Length;
        }

        public static int CountDistinct(int[] nums)
        {
            return new HashSet<int>(nums).Count;
        }

        public static char? FirstRepeatChar(string s)
        {
            HashSet<char> set = new();
            foreach (char c in s)
            {
                if (set.Contains(c))
                {
                    return c;
                }
                set.Add(c);
            }

            return null;
        }

        public static List<string> UniqueWords(string text)
        {
            var words = Regex.Matches(text, @"\w+")
                .Select(x => x.Value.ToLower());

            return new HashSet<string>(words).ToList();
        }

        public static List<(int, int)> FindPairsWithSum(int[] nums, int target)
        {
            HashSet<int> seen = [];
            HashSet<(int, int)> result = [];

            foreach (int num in nums)
            {
                int complement = target - num;
                if (seen.Contains(complement))
                {
                    int first = Math.Min(num, complement);
                    int second = Math.Max(num, complement);
                    result.Add((first, second));
                }
                seen.Add(num);
            }

            return result.ToList();
        }

        public static List<(int, int)> FindUniquePairsSum(int[] nums, int target)
        {
            var result = new List<(int, int)>();
            var seen = new HashSet<int>();
            var used = new HashSet<int>(); // avoid duplicates

            foreach (int x in nums)
            {
                int complement = target - x;

                if (seen.Contains(complement) && !used.Contains(x) && !used.Contains(complement))
                {
                    result.Add((Math.Min(x, complement), Math.Max(x, complement)));
                    used.Add(x);
                    used.Add(complement);
                }

                seen.Add(x);
            }
            return result;
        }

        public static bool HasCycle(ListNode head)
        {
            var visited = new HashSet<ListNode>();

            while (head != null)
            {
                if (!visited.Add(head))
                    return true;
                head = head.Next;
            }
            return false;
        }

        public static bool PathCrosses(List<(int x, int y)> path)
        {
            var visited = new HashSet<(int, int)>();

            foreach (var point in path)
            {
                if (!visited.Add(point))
                {
                    return true;
                }
            }
            return false;
        }

        public static int CountAnagramGroups(string[] words)
        {
            var set = new HashSet<string>();

            foreach (var w in words)
            {
                char[] arr = w.ToCharArray();
                Array.Sort(arr);

                set.Add(new string(arr));
            }

            return set.Count;
        }

        // Given arrays a and b, return elements that are in a but not in b using HashSet and LINQ.
        public static int[] MissingElements(int[] a, int[] b)
        {
            var set = new HashSet<int>(b);
            return a.Where(x => !set.Contains(x)).ToArray();
        }

        // Given a paragraph, return duplicate words and how many times each appears — case insensitive.
        public static Dictionary<string, int> DuplicateWords(string text)
        {
            var words = Regex.Matches(text, @"\w+")
                .Select(x => x.Value);

            return words.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .ToDictionary(x => x.Key, g => g.Count());
        }

        // Find Numbers That Appear in At Least Two of Three Arrays
        public static int[] AppearingInAtLeastTwo(int[] a, int[] b, int[] c)
        {
            var sets = new[]
            {
                new HashSet<int>(a),
                new HashSet<int>(b),
                new HashSet<int>(c)

            };

            return sets.SelectMany(s => s)
                .GroupBy(x => x)
                .Where(g => g.Count() >= 2)
                .Select(g => g.Key)
                .ToArray();
        }

        // Given string text1 and string text2, return the words that appear exactly once in total, across BOTH texts.
        public static string[] UniqueAcrossTwo(string t1, string t2)
        {
            var words = t1 + " " + t2;
            var list = Regex.Matches(words, @"\w+")
                .Select(x => x.Value);

            return list.GroupBy(w => w)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .ToArray();
        }

        // Given an array, return all unique triplets (a, b, c) where: a + b + c = 0
        public static List<(int, int, int)> ZeroSumTriplets(int[] nums)
        {
            var unique = new HashSet<(int, int, int)>();

            for (int i = 0; i < nums.Length; i++)
            {
                var seen = new HashSet<int>();
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int third = -nums[i] - nums[j];

                    if (seen.Contains(third))
                    {
                        var triplet = new[] { nums[i], nums[j], third }
                                      .OrderBy(x => x).ToArray();

                        unique.Add((triplet[0], triplet[1], triplet[2]));
                    }

                    seen.Add(nums[j]);
                }
            }

            return [.. unique];
        }

        public static void ZeroSumTriplets_Test()
        {
        }

        // Given a list of logs:
        //
        // List<List<string>> logs = new List<List<string>>
        // {
        //     new () { "a", "b", "c" },
        //     new () { "b", "c", "d" },
        //     new () { "b", "e", "c" }
        // };
        // Return all users that appear in every log.
        //
        public static string[] UsersInAllLogs(List<List<string>> logs)
        {
            return logs.Select(log => new HashSet<string>(log))
                       .Aggregate((h1, h2) => { h1.IntersectWith(h2); return h1; })
                       .ToArray();
        }

        public static void UsersInAllLogs_Test()
        {
            List<List<string>> logs = new List<List<string>>
             {
                 new() { "a", "b", "c" },
                 new () { "b", "c", "d" },
                 new () { "b", "e", "c" }
             };

            var users = UsersInAllLogs(logs);
            Console.WriteLine($"Users in all logs: {string.Join(", ", users)}");
        }
    }
}
