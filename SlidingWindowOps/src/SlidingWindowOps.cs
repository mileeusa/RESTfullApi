using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SlidingWindowInAction.src
{
    public class SlidingWindowOps
    {
        //
        // You are given an array of integers nums, there is a sliding window of size k
        // which is moving from the very left of the array to the very right. You can
        // only see the k numbers in the window. Each time the sliding window
        // moves right by one position.
        //
        // Return the max sliding window.
        //
        // Example 1:
        //   Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
        //   Output: [3, 3, 5, 5, 6, 7]
        //
        // LeetCode 239. Sliding Window Maximum
        //
        // Difficulty: Hard
        //
        // Implementation:
        //    We maintain a monotonic decreasing deque of indices:
        //      -- Front of deque → index of the current window max
        //      -- Back of deque → smaller elements that are no longer useful
        //      -- Each index is added and removed once → O(n)
        //
        public static int[] MaxSlidingWindow_Dequeue(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return Array.Empty<int>();

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            var deque = new LinkedList<int>(); // store indices

            for (int i = 0; i < n; i++)
            {
                // Remove indices outside the window
                if (deque.Count > 0 && deque.First!.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                // Maintain decreasing order
                while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                    result[i - k + 1] = nums[deque.First!.Value];
            }

            return result;
        }

        //
        // You are given an array of integers nums, there is a sliding window of size k
        // which is moving from the very left of the array to the very right. You can
        // only see the k numbers in the window. Each time the sliding window
        // moves right by one position.
        //
        // Return the max sliding window.
        //
        // LeetCode: 239. Sliding Window Maximum
        //
        // Difficulty: Hard
        //
        // Time complexity:  O(M * K)
        // Space complexity: O(M - K)
        //
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0) return [];

            int n = nums.Length;
            int[] result = new int[n - k + 1];

            for (int i = 0; i < n - k + 1; i++)
            {
                int max = nums[i];
                for (int j = 0; j < k; j++)
                {
                    max = Math.Max(max, nums[i + j]);
                }

                result[i] = max;
            }

            return result;
        }

        //
        // Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        // In other words, return true if one of s1's permutations is the substring of s2.
        // 
        // Example 1:
        //   Input: s1 = "ab", s2 = "eidbaooo"
        //   Output: true
        //   Explanation: s2 contains one permutation of s1("ba").
        //
        // Example 2:
        //   Input: s1 = "ab", s2 = "eidboaoo"
        //   Output: false
        //
        // LeetCode 567. Permutation in String
        //
        // Difficulty: medium
        //
        public static bool CheckInclusion(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length > s2.Length)
                return false;

            int m = s1.Length;
            int n = s2.Length;

            var freq1 = new int[26];
            foreach (var c in s1)
                freq1[c - 'a']++;

            var freq2 = new int[26];

            for (int i = 0; i < n; i++)
            {
                freq2[s2[i] - 'a']++;
                if (i >= m)
                {
                    freq2[s2[i - m] - 'a']--;
                }

                if (i >= m - 1 && IsMatch(freq1, freq2))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsMatch(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckInclusion_SlidingWindow(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length > s2.Length)
                return false;

            int[] freq = new int[26];

            foreach (char c in s1)
                freq[c - 'a']++;

            int left = 0;
            int needed = s1.Length;

            for (int right = 0; right < s2.Length; right++)
            {
                int r = s2[right] - 'a';

                if (freq[r] > 0)
                    needed--;

                freq[r]--;

                if (right - left + 1 > s1.Length)
                {
                    int l = s2[left] - 'a';

                    if (freq[l] >= 0)
                        needed++;

                    freq[l]++;
                    left++;
                }

                if (needed == 0)
                    return true;
            }

            return false;
        }
    }
}
