namespace RailwayPark.Services
{
    public sealed class AreaIDGenerator
    {
        /// <summary>
        /// Явный статический конструктор.
        /// </summary>
        static AreaIDGenerator() { }

        /// <summary>
        /// Закрытый конструктор.
        /// </summary>
        private AreaIDGenerator() { }

        private uint nextID = 1;

        private static readonly AreaIDGenerator source = new AreaIDGenerator();

        public static AreaIDGenerator Source
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
