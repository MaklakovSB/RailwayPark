namespace Graph
{
    /// <summary>
    /// Вершины графа.
    /// </summary>
    public class GraphVertex
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GraphVertex(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
