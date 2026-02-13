using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.src
{
    public class SlidingWindowOps
    {
        // 
        // return a longest substring where each unique charater
        // cannot appear over K tims
        //
        // "aabcbba", k = 2 ==> "aabcb"
        //
        public static string LongestSubstring(string s, int k)
        {
            if (string.IsNullOrEmpty(s) || k <= 0 || s.Length < k)
            {
                return "";
            }

            var freq = new int[26];

            int maxLen = 0;
            int left = 0;
            int startIdx = 0;

            for (int right = 0; right < s.Length; right++)
            {
                int idx = s[right] - 'a';
                freq[idx]++;

                while (freq[idx] > k)
                {
                    freq[s[left] - 'a']--;
                    left++;
                }

                int len = right - left + 1;

                if (len > maxLen)
                {
                    maxLen = len;
                    startIdx = left;
                }
            }

            return s.Substring(startIdx, maxLen);
        }
    }
}
