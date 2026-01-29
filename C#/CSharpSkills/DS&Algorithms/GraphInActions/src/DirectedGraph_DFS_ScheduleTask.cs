using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class DirectedGraph_DFS_ScheduleTask
    {
        //
        //
        // Eric has n=7 tasks to complete. His manager gives him m=6 notes on the order tasks must
        // be performed. Here is a graph of the dependencies.The dependent array,
        // a = [1, 2, 3, 4, 6, 5]. His principal tasks array, b = [7, 6, 4, 1, 2, 1].
        //
        // Here is a graph of the dependencies. a = [1,2,3,4,6,5] b = [7,6,4,1,2,1]
        // Disjoint directed graph.
        //
        // Nodes 2 and 6 have two edges forming a cycle. The other subgraph is 7-1-4-3 and 1-5.
        //
        // From the graph, it is easy to see that task 6 must be performed before task 2 and vice versa.
        // He can only complete one of those two tasks before the other, so he must choose either
        // task 6 or 2. He can complete 7 - 1 = 6 tasks. Function Description Complete the
        // function tasks in the editor below. It must return an integer denoting the maximum
        // number of tasks that Eric can complete. tasks has the following parameter(s):
        // n: integer, the number of tasks a[a[0],...a[n-1]]: an array of integers,
        // the dependent tasks b[b[0],...b[n-1]]: an array of integers,

        // the primary tasks Constraints
        // 1 ≤ n ≤ 105 0 ≤ m ≤ n 1 ≤ a[i],
        // b[i] ≤ n Each task depends on at most one other task.
        //              
        static int tasks(int n, List<int> a, List<int> b)
        {
            return 0;
        }
    }
}
