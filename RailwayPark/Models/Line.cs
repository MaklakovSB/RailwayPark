using RailwayPark.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public class Line : BasePrimitive
    {
        /// <summary>
        /// Коллекция Points.
        /// </summary>
        public ObservableCollection<Point> Points
        {
            get { return points; }
        }
        private ObservableCollection<Point> points = new ObservableCollection<Point>();

        /// <summary>
        /// Цвет заливки.
        /// </summary>
        public Color Fill
        {
            get { return fill; }
            set { fill = value; }
        }
        private Color fill = Brushes.Transparent.Color;

        public override string PrimitiveType => "Line";
    }
}
