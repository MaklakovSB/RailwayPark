using RailwayPark.Models;
using RailwayPark.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace RailwayPark.ViewModels
{
    public sealed class Area : BasePrimitive
    {
        /// <summary>
        /// Идентификатор линии.
        /// </summary>
        public int AreaID { protected set; get; }

        /// <summary>
        /// Коллекция Points.
        /// </summary>
        public ObservableCollection<Point> Points
        {
            get { return points; }
        }
        private ObservableCollection<Point> points = new ObservableCollection<Point>();

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Area()
        {
            AreaID = AreaIDGenerator.Source.nextId();
        }

        public override string PrimitiveType => "Area";
    }
}
