using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RailwayPark.Converters
{
    /// <summary>
    /// Конвертер коллекций Piont входящих в объекты Line.
    /// Коллекции Piont описывают геометрию ломаной линии.
    /// </summary>
    public class PointCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(ObservableCollection<Point>) && targetType == typeof(PointCollection))
            {
                var pointCollection = new PointCollection();

                foreach (var point in value as ObservableCollection<Point>)
                {
                    pointCollection.Add(point);
                }

                return pointCollection;
            }

            throw new ArgumentException("Не правильный тип одного из аргументов либо обоих: value, targetType");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Метод обратной конвертации не поддерживается");
        }
    }
}
