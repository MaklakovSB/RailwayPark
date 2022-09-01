using System;

namespace RailwayPark.Models
{
    public abstract class BasePrimitive
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public int Z { get; set; }
        public Double Height { get; set; }
        public Double Width { get; set; }

        public abstract string PrimitiveType 
        {
            get; 
        }
    }
}
