using RailwayPark.Models;
using RailwayPark.Services;

namespace RailwayPark.ViewModels
{
    public sealed class Vertex : BasePrimitive
    {
        public uint VertexID { protected set; get; }

        public Vertex()
        {
            VertexID = VertexIDGenerator.Source.nextId();
        }

        public override string PrimitiveType => "Vertex";
    }
}
