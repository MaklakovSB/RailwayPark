namespace Graph
{
    /// <summary>
    /// Вершины графа.
    /// </summary>
    public class GraphVertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public GraphVertex(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
