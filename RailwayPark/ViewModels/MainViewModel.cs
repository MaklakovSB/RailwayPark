using RailwayPark.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public class MainViewModel : IViewModel, INotifyPropertyChanged
    {
        #region Свойства и поля

        /// <summary>
        /// Выбираемый цвет заливки.
        /// </summary>
        public Color SelectedFillColor
        {
            get
            {
                return selectedFillColor;
            }
            set
            {
                selectedFillColor = value;
                OnPropertyChanged(nameof(SelectedFillColor));
                OnPropertyChanged(nameof(FillColorBrush));
            }
        }
        private Color selectedFillColor = Brushes.LightGoldenrodYellow.Color;

        /// <summary>
        /// Цвет заливки.
        /// </summary>
        public Brush FillColorBrush => (Brush)new SolidColorBrush(SelectedFillColor);

        #endregion

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {

        }

        #region Имплементация IViewModel

        public event Action Close;

        public virtual void OnClose()
        {
            Close?.Invoke();
        }

        #endregion

        #region Имплементация INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
