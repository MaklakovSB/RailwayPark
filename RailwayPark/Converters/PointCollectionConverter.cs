using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RailwayPark.Converters
{
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

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }
    }
}
