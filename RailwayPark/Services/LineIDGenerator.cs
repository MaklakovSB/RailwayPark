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

        private uint nextID = 1;

        private static readonly LineIDGenerator source = new LineIDGenerator();

        public static LineIDGenerator Source
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
