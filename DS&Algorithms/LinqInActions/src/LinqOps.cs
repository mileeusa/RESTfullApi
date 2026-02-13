using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LinqInActions.src
{
    public class Item
    {
        public string Group;
        public int Value;
    }

    public class LinqOps
    {
        // Given an integer array, return the numbers that appear exactly once using LINQ and HashSet.
        public static int[] AppearingOnce(int[] nums)
        {
            return nums.GroupBy(x => x)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .ToArray();
        }

        // Given int[] nums and int k, return numbers appearing more than k times.
        public static int[] AppearingMoreThanK(int[] nums, int k)
        {
            return nums.GroupBy(x => x)
                .Where(g => g.Count() > k)
                .Select(g => g.Key)
                .ToArray();
        }

        //
        // Given a List<int[]> datasets and an integer n, return IDs that appear in at least n datasets, not n times.
        //
        // Example: If ID 42 appears in dataset 1 and dataset 3, that counts as 2, even if it appears 100 times in each.
        //
        public static int[] AppearingInAtLeastNDatasets(List<int[]> datasets, int n)
        {
            // step 1: converting huge datasets to HashSets to dedupe locally
            // step 2: using LINQ’s flatten/ group patterns
            // step 3: dataset - level distinctness, not value-level
            // step 4: filtering by count of datasets
            //
            var perDatasetSets = datasets.Select(dataset => new HashSet<int>(dataset));

            return perDatasetSets
                .SelectMany(set => set)
                .GroupBy(id => id)
                .Where(g => g.Count() >= n)
                .Select(g => g.Key)
                .ToArray();
        }

        // Given a list of integer sets, compute the symmetric difference (elements that appear in exactly one set).
        public static int[] SymmetricDifference(List<HashSet<int>> sets)
        {
            return sets.SelectMany(s => s)
                       .GroupBy(x => x)
                       .Where(g => g.Count() == 1)
                       .Select(g => g.Key)
                       .ToArray();
        }

        // You have roles and permissions:
        //
        // Dictionary<string, HashSet<string>> roles;
        //
        // Given a user with several roles, return permissions that are explicitly
        // conflicting — meaning:
        //
        //   one role contains a permission
        //   another role contains the negative version of it, like "read" vs "!read"
        public static string[] Conflicts(IEnumerable<string> userRoles,
                                 Dictionary<string, HashSet<string>> roles)
        {
            var allPerms = userRoles
                .SelectMany(r => roles[r])
                .ToArray();

            var permSet = new HashSet<string>(allPerms);

            return allPerms
                .Where(p => p.StartsWith("!") && permSet.Contains(p[1..]) ||
                            !p.StartsWith("!") && permSet.Contains("!" + p))
                .Distinct()
                .ToArray();
        }

        // Return values that appear exactly once per group, but may appear in other groups.
        public static int[] AppearingOncePerGroup(List<Item> items)
        {
            return items
                .GroupBy(i => i.Group)
                .SelectMany(g => g
                    .GroupBy(i => i.Value)
                    .Where(gg => gg.Count() == 1)
                    .Select(gg => gg.Key))
                .Distinct()
                .ToArray();
        }

        public static List<string> SuspiciousUsers(Dictionary<string, List<string>> logs, HashSet<(string, string)> forbidden)
        {
            return logs
                .Where(entry =>
                {
                    var events = entry.Value;
                    return Enumerable.Range(0, events.Count - 1)
                        .Any(i => forbidden.Contains((events[i], events[i + 1])));
                })
                .Select(x => x.Key)
                .ToList();
        }

        // Given 100K+ HashSets of ints, compute their intersection.
        //
        // Note: you must use LINQ + HashSet in a performance-aware way.
        //
        public static HashSet<int> IntersectAll(List<HashSet<int>> sets)
        {
            // Sort by size for efficiency
            // avoiding nested intersections
            // LINQ aggregate over mutable set

            var ordered = sets.OrderBy(s => s.Count).ToList();

            return ordered.Skip(1)
                          .Aggregate(new HashSet<int>(ordered[0]),
                                     (acc, s) =>
                                     {
                                         acc.IntersectWith(s);
                                         return acc;
                                     });
        }
    }
}
