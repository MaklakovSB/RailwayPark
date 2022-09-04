using RailwayPark.Models;
using RailwayPark.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public sealed class Area : BasePrimitive, INotifyPropertyChanged
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
        private Color fill = Brushes.Bisque.Color;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Area()
        {
            AreaID = AreaIDGenerator.Source.nextId();
        }

        public override string PrimitiveType => "Area";

        #region Имплементация INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
