namespace RailwayPark.Services
{
    /// <summary>
    /// Генератор идентификаторов для объектов Vertex.
    /// </summary>
    public sealed class VertexIDGenerator
    {
        /// <summary>
        /// Явный статический конструктор.
        /// </summary>
        static VertexIDGenerator() { }

        /// <summary>
        /// Закрытый конструктор.
        /// </summary>
        private VertexIDGenerator() { }

        private uint nextID = 1;

        private static readonly VertexIDGenerator source = new VertexIDGenerator();

        public static VertexIDGenerator Source
        {
            get
            {
                return source;
            }
        }

        public uint nextId()
        {
            return nextID++;
        }
    }
}
