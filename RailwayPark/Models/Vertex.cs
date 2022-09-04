using RailwayPark.Models;
using RailwayPark.Services;
using System.ComponentModel;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public sealed class Vertex : BasePrimitive, INotifyPropertyChanged
    {
        public int VertexID { private set; get; }

        /// <summary>
        /// Цвет заливки.
        /// </summary>
        public Color Fill
        {
            get { return fill; }

            set
            {
                fill = value;
                OnPropertyChanged(nameof(Fill));
            }
        }
        private Color fill = Brushes.Brown.Color;

        public Vertex()
        {
            VertexID = VertexIDGenerator.Source.nextId();
        }

        public override string PrimitiveType => "Vertex";

        #region Имплементация INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
