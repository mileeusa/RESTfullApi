using GraphInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.UnitTests
{
    [TestFixture]
    public class ShortestDistanceOpsTests
    {
        static object[] testdata =
        {
            new object[]
            {
                new int[][]
                {
                    [ 2, 4 ],
                    [ 0, 2 ],
                    [ 0, 4 ]
                },
                5,
                new int[] {3, 2, 1},

                //new int[][]
                //{
                //    [ 0, 3 ],
                //    [ 0, 2 ]
                //},
                //4,
                //new int[] {1, 1}
            }
        };

        [TestCaseSource(nameof(testdata))]
        public void ShortestDistanceAfterQueries_Test(int[][] queries, int k, int[] expected)
        {
            var result = ShortestDistanceOps.ShortestDistanceAfterQueries(k, queries);

            CollectionAssert.AreEqual(result, expected);
        }
    }
}
