using Graph;
using NUnit.Framework;

namespace CommonTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGraph()
        {
            GraphDFS graph = new GraphDFS();

            graph.Verteces.Add(new GraphVertex(0, 0));
            graph.Verteces.Add(new GraphVertex(1, 0));
            graph.Verteces.Add(new GraphVertex(2, 2));
            graph.Verteces.Add(new GraphVertex(0, 2));

            graph.Verteces.Add(new GraphVertex(2, 0));

            graph.Edges.Add(new GraphEdge(0, 1));
            graph.Edges.Add(new GraphEdge(1, 2));
            graph.Edges.Add(new GraphEdge(2, 3));
            graph.Edges.Add(new GraphEdge(3, 0));

            graph.Edges.Add(new GraphEdge(1, 4));
            graph.Edges.Add(new GraphEdge(4, 2));

            graph.CyclesSearch();

            var test = graph.Cycles;

            if(test.Count == 3)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }       
        }
    }
}