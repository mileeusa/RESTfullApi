using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace DynamicProgrammingInActions.src
{
    public class Box
    {
        public int W;
        public int D;
        public int H;
        public override string ToString() => $"{W} {D} {H}";
    }

    public class StackBoxesOps
    {
        // Stack of Boxes. Classic interview problem
        //
        // You’re given n boxes. Each box has dimensions(width, height, depth).
        // You can stack box A on box B only if all three dimensions of A are strictly smaller than B.
        //
        // 👉 Find the maximum possible height of a stack.
        //
        // Variants:
        //   Rotation allowed / not allowed
        //   Return height only vs return actual stack
        //   2D version (envelopes) vs 3D boxes
        //
        // Key interview insight
        //   This is a Longest Increasing Subsequence–style DP, but instead of length, we maximize total height.
        //
        // Think:
        //   What’s the tallest stack with box i on top?
        //
        // Step 1: Normalize + sort
        //   If rotation is NOT allowed
        //     Sort boxes by:
        //       width ↑
        //       depth ↑
        //       height ↑ (tie-breaker)
        //   If rotation IS allowed
        //     For each box, generate 3 rotations where:
        //       height is fixed
        //       base(w, d) is ordered so w ≤ d
        //     Then sort by:
        //       base area(w * d) descending (or w desc, d desc)
        //
        // This ensures when we process boxes, all valid bases come first.
        //
        // Step 2: DP definition
        //   Let:
        //     dp[i] = max stack height with box i at the top

        public static int MaxStackHeight(Box[] boxes)
        {
            Array.Sort(boxes, (x, y) =>
            {
                if (x.W != y.W) return x.W.CompareTo(y.W);
                if (x.D != y.D) return x.D.CompareTo(y.D);

                return x.H.CompareTo(y.H);
            });

            int n = boxes.Length;
            var dp = new int[n];
            int maxHeight = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = boxes[i].H;

                for (int j = 0; j < i; j++)
                {
                    if (boxes[j].W < boxes[i].W &&
                        boxes[j].D < boxes[i].D &&
                        boxes[j].H < boxes[i].H)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + boxes[i].H);
                    }
                }

                maxHeight = Math.Max(maxHeight, dp[i]);
            }

            return maxHeight;
        }

        public static List<Box> GetMaxHeightStack(Box[] boxes)
        {
            if (boxes == null || boxes.Length == 0)
                return new List<Box>();

            int n = boxes.Length;
            var dp = new int[n];
            var parent = new int[n]; // save the index to reconstruct the list of boxes

            Array.Fill(parent, -1);

            int maxHeight = 0;
            int maxIndex = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = boxes[i].H;

                for (int j = 0; j < i; j++)
                {
                    if (boxes[j].W < boxes[i].W &&
                        boxes[j].D < boxes[i].D &&
                        boxes[j].H < boxes[i].H)
                    {
                        if (dp[i] < dp[j] + boxes[i].H)
                        {
                            dp[i] = dp[j] + boxes[i].H;
                            parent[i] = j;
                        }
                    }
                }

                if (dp[i] > maxHeight)
                {
                    maxHeight = dp[i];
                    maxIndex = i;
                }
            }

            // construct the stacks
            List<Box> stack = new List<Box>();

            int cur = maxIndex;
            while (cur != -1)
            {
                stack.Add(boxes[cur]);
                cur = parent[cur];
            }

            stack.Reverse();

            return stack;
        }
    }
}
