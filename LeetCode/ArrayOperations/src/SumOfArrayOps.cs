using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class SumOfArrayOps
    {
        //
        // return the pair of numbers from the unsorted array that sum up to the target
        //
        public static int[] TwoSum_UnsortedArray(int[] nums, int target)
        {
            var map = new Dictionary<int, int>(); // complement vs index

            for (int i = 0; i < nums.Length; i++)
            {
                var key = target - nums[i];
                if (map.TryGetValue(key, out int value))
                {
                    return [value, i]; // new int[] { value, i };
                }

                map.TryAdd(nums[i], i);
            }

            return [];
        }

        //
        // return the pair of numbers from the sorted array that sum up to the target 
        //
        // Time complexity: O(N)
        //
        public static IList<int[]> TwoSum_SortedArray(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            var result = new List<int[]>();

            while (start < end)
            {
                var sum = nums[start] + nums[end];

                if (sum == target)
                {
                    result.Add([start, end]);
                }

                if (sum < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return result;
        }

        //
        // return the elements in the sorted array that sum up to zero
        //
        // LeetCode: 15. 3Sum
        //
        // Time complexity: O(N^2)
        // Space complexity: O(1)
        //
        // Difficulty: Medium
        //
        public static IList<IList<int>> ThreeSum(int[] nums, int target)
        {
            // if nums are not sorted, then we should sort first
            Array.Sort(nums);

            var result = new List<IList<int>>();

            int n = nums.Length;

            for (int i = 0; i < n - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue; // skip duplicates
                }

                // pruning
                if (nums[i] + nums[i + 1] + nums[i + 2] > target)
                    break;

                if (nums[i] + nums[n - 2] + nums[n - 1] < target)
                    continue;

                int left  = i + 1;
                int right = n - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == target)
                    {
                        result.Add(new int[] { nums[i], nums[left], nums[right] });

                        // remove the duplicates for left
                        while (left < right && nums[left] == nums[left + 1]) left++;

                        // remove the duplicates for right
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        //
        // Given an integer array nums and an integer target, return all unique quadruplets
        //     [nums[a], nums[b], nums[c], nums[d]] such that:
        //     a, b, c, d are distinct
        //     nums[a] + nums[b] + nums[c] + nums[d] == target
        //     No duplicate quadruplets in the answer.
        //
        // LeetCode 18. 4Sum
        //
        // Time complexity:  O(N^3)
        // Space complexity: O(1), excluding the result list
        //
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 3) return [];

            Array.Sort(nums);
            var res = new List<IList<int>>();

            int n = nums.Length;

            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                long min1 = (long)nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3];
                if (min1 > target) break;

                long max1 = (long)nums[i] + nums[n - 1] + nums[n - 2] + nums[n - 3];
                if (max1 < target) continue;

                for (int j = i + 1; j < n - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                    long min2 = (long)nums[i] + nums[j] + nums[j + 1] + nums[j + 2];
                    if (min2 > target) break;

                    long max2 = (long)nums[i] + nums[j] + nums[n - 1] + nums[n - 2];
                    if (max2 < target) continue;

                    int left = j + 1;
                    int right = n - 1;

                    while (left < right)
                    {
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            res.Add(new List<int>
                            {
                                nums[i],
                                nums[j],
                                nums[left],
                                nums[right]
                            });

                            left++;
                            right--;

                            // prune
                            while (left < right && nums[left] == nums[left - 1]) left++;
                            while (left < right && nums[right] == nums[right + 1]) right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return res;
        }
    }
}
