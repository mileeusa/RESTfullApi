using NUnit.Framework;

namespace GraphInActions.UnitTests
{
    [TestFixture]
    public class GraphTraversalTests
    {
        [Test]
        public static void GraphTraversal_Test()
        {
            // arrange

            // Create a graph with 6 vertices
            GraphTraversal graph = new GraphTraversal(6);
            // Add edges
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);
            // Perform BFS starting from vertex 0
            Console.Write("Breadth-First Search starting from vertex 0: ");

            // act
            var list = graph.GraphTraversalBFS(0);

            // assert
            Console.WriteLine();
            Console.WriteLine("=> BFS Traversal Order: " + string.Join(" ", list));

            Assert.That(list[3], Is.EqualTo(3));
        }
    }
}
