using TreeInActions.src;
using TreeInActions.UnitTests;

namespace TreeInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MiniDepthOpsTests.MinDepthDPS_Test();
            MiniDepthOpsTests.MinDepthBFS_Test();
            MiniDepthOpsTests.MinDepthBFS_2_Test();

            MaxDepthOpsTests.MaxDepthDPS_Test();
            MaxDepthOpsTests.MaxDepthBFS_Test();

            PathSumOpsTests.PathSum_Test();
            PathSumOpsTests.PathSumAll_Test();
            PathSumOpsTests.MaxPathSum_Test();
        }
    }
}
