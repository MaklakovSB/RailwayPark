using System;

namespace RailwayPark.Models
{
    public abstract class BasePrimitive
    {
        public uint Id { set; get; }
        public Double X { set; get; }
        public Double Y { set; get; }
        public int Z { set; get; }
        public Double Height { set; get; }
        public Double Width { set; get; }

        public abstract string PrimitiveType 
        {
            get; 
        }
    }
}
