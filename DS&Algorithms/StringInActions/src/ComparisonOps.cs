using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace StringInActions.src
{
    public class ComparisonOps
    {
        // 
        // Given two version strings, version1 and version2, compare them. A version string consists
        // of revisions separated by dots '.'. The value of the revision is its integer conversion
        // ignoring leading zeros.
        //
        // To compare version strings, compare their revision values in left-to-right order.If one
        // of the version strings has fewer revisions, treat the missing revision values as 0.
        //
        // Return the following:
        //   If version1 < version2, return -1.
        //   If version1 > version2, return 1.
        //   Otherwise, return 0.
        //
        // LeetCode 165. Compare Version Numbers
        //
        // Time complexity: O(N+M)
        // Space complexity: O(M+N)
        //
        // Difficulty: Medium
        //
        public static int CompareVersion(string version1, string version2)
        {
            var v1 = version1.Split('.');
            var v2 = version2.Split('.');

            int maxLength = Math.Max(v1.Length, v2.Length);

            for (int i = 0; i < maxLength; i++)
            {
                int num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
                int num2 = i < v2.Length ? int.Parse(v2[i]) : 0;

                if (num1 > num2) return 1;
                if (num1 < num2) return -1;
            }

            return 0;
        }
    }
}
