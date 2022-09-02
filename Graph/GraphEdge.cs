namespace Graph
{
    /// <summary>
    /// Ребра графа.
    /// </summary>
    public class GraphEdge
    {
        public int Vertex1 { get; set; }
        public int Vertex2 { get; set; }

        public GraphEdge(int vertex1, int vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }
    }
}
