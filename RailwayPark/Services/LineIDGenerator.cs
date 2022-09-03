namespace RailwayPark.Services
{
    /// <summary>
    /// Генератор идентификаторов для объектов Line.
    /// </summary>
    public sealed class LineIDGenerator
    {
        /// <summary>
        /// Явный статический конструктор.
        /// </summary>
        static LineIDGenerator() { }

        /// <summary>
        /// Закрытый конструктор.
        /// </summary>
        private LineIDGenerator() { }

        private int nextID = 0;

        private static readonly LineIDGenerator source = new LineIDGenerator();

        public static LineIDGenerator Source
        {
            get
            {
                return source;
            }
        }

        public int nextId()
        {
            return nextID++;
        }

        public void ResetCounter()
        {
            nextID = 0;
        }
    }
}
