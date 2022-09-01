using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RailwayPark.Converters
{
    public class VertexPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value.GetType() == typeof(object[]))
            {
                if (targetType == typeof(double))
                {
                    if (value.Length == 2)
                    {
                        if(value[0].GetType() == typeof(double) && value[1].GetType() == typeof(string))
                        {
                            var Value = (double)value[0];

                            if ((string)value[1] == "Vertex")
                            {
                                return Value - 1;
                            }
                            else
                            {
                                return Value;
                            }
                        }
                        else { throw new ArgumentException("Не правильные типы значений внутри мвссива value"); }
                    }
                    else { throw new ArgumentException("Не правильное значение Length аргумента value"); }
                }
                else { throw new ArgumentException("Не правильный тип аргумента targetType"); }
            }
            else { throw new ArgumentException("Не правильный тип аргумента value"); }           
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Метод обратной конвертации не поддерживается");
        }
    }
}