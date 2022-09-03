using RailwayPark.Enums;
using RailwayPark.Models;
using RailwayPark.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace RailwayPark.Factory
{
    public static class PrimitiveFactory
    {
        public static BasePrimitive GetBasePrimitive(PrimitiveEnum primitiveEnum, int x , int y, int z, List<Point> points = null, 
            List<Vertex> verteces = null)
        {
            switch (primitiveEnum)
            {
                case PrimitiveEnum.Vetex:

                    return new Vertex() { X = x, Y = y, Z = z};

                case PrimitiveEnum.Line:

                    if(points == null)
                    {
                        throw new ArgumentException("PrimitiveFactory: не обнаружено данных об объектах Point для объекта Line.");
                    }

                    if(points.Count < 2)
                    {
                        throw new ArgumentException("PrimitiveFactory: не достаточно данных об объектах Point для объекта Line.");
                    }

                    if (points.First().X == points.Last().X && points.First().Y == points.Last().Y)
                    {
                        throw new ArgumentException("PrimitiveFactory: не верные данные об объектах Point для объекта Line.");
                    }

                    if (verteces == null)
                    {
                        throw new ArgumentException("PrimitiveFactory: Построение объекта Line не может быть " +
                            "завершено список возможных замыкающих вершин null.");
                    }

                    if (verteces.Count < 2)
                    {
                        throw new ArgumentException("PrimitiveFactory: Построение объекта Line не может быть " +
                            "завершено список возможных замыкающих вершин меньше двух.");
                    }

                    var line = new Line() { Z = 1 };

                    foreach(var point in points)
                    {
                        line.Points.Add(new Point(point.X, point.Y));
                    }

                    line.DetectAndFillTrailingVertices(verteces);

                    return line;

                case PrimitiveEnum.Area:

                    if (points == null)
                    {
                        throw new ArgumentException("PrimitiveFactory: не обнаружено данных об объектах Point для объекта Area.");
                    }

                    if (points.Count < 4)
                    {
                        throw new ArgumentException("PrimitiveFactory: не достаточно данных об объектах Point для объекта Area.");
                    }

                    if (points.First().X != points.Last().X || points.First().Y != points.Last().Y)
                    {
                        throw new ArgumentException("PrimitiveFactory: не верные данные об объектах Point для объекта Area.");
                    }

                    var area = new Area() { Z = 0 };

                    foreach (var point in points)
                    {
                        area.Points.Add(new Point(point.X, point.Y));
                    }

                    return area;

                default:

                    throw new NotSupportedException("Фабричный тип не поддерживается.");
            }
        }
    }
}
