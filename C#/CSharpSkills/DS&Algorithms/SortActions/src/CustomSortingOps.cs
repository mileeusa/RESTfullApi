using SortActions.src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortActions.src
{
    public class CustomSortingOps
    {
        // Sort Words by Frequency, Then Alphabetically
        public static List<string> SortingBasedOnWordFrequency(List<string> words)
        {
            var freq = words.GroupBy(w => w)
                .ToDictionary(g => g.Key, g => g.Count());

            var comparer = Comparer<string>.Create((a, b) =>
            {
                var cmp = freq[b].CompareTo(freq[a]);

                if (cmp != 0)
                {
                    return cmp;
                }

                return string.Compare(a, b, StringComparison.Ordinal);
            });

            words.Sort(comparer);

            return words;
        }

        // Implement a Natural Sort Order (“file10” > “file2”)
        //
        // Given filenames like:
        //    file1
        //    file20
        //    file3
        //    file10
        //
        // Expected 'natural sort' output:
        //
        //    file1, file3, file10, file20
        //
        // You must write a custom comparer that:
        //    - Extracts numeric suffixes
        //    - Compares numeric parts as integers
        //    - Falls back to string comparison if no number exists
        //
        public static void SortNaturally(List<string> list)
        {
            Regex suffix = new (@"\d+$", RegexOptions.Compiled);

            var comparer = Comparer<string>.Create((a, b) =>
            {
                var ma = suffix.Match(a);
                var mb = suffix.Match(b);

                if (ma.Success && mb.Success)
                {
                    if (int.TryParse(ma.Value, out int va) && int.TryParse(mb.Value, out int vb))
                    {
                        int cmp = va.CompareTo(vb);

                        if (cmp != 0)
                        {
                            return cmp;
                        }
                    }
                }
                else if (ma.Success)
                {
                    return -1;
                }
                else if (mb.Success)
                {
                    return 1;
                }

                return string.Compare(a, b, StringComparison.Ordinal);
            });

            list.Sort(comparer);
        }

        // Sort Linked List Nodes by Value, then by List Length
        public static void SortLinkedList(List<ListNode> list)
        {
            var comparer = Comparer<ListNode>.Create((a, b) =>
            {
                int cmp = a.Val.CompareTo(b.Val);

                if (cmp != 0)
                {
                    return cmp; 
                }

                int la = GetLengthOfLinkedList(a);
                int lb = GetLengthOfLinkedList(b);

                return la.CompareTo(lb);

            });

            list.Sort(comparer);
        }

        public static int GetLengthOfLinkedList(ListNode node)
        {
            int len = 0;
            while (node != null)
            {
                len++;
                node = node.Next;
            }

            return len;
        }
    }
}
