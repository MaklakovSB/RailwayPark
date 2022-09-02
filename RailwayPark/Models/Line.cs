using RailwayPark.Models;
using RailwayPark.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public sealed class Line : BasePrimitive
    {
        /// <summary>
        /// Идентификатор линии.
        /// </summary>
        public uint LineID { protected set; get; }

        /// <summary>
        /// Первая замыкающая вершина.
        /// </summary>
        public uint Vertex1 { set; get; }

        /// <summary>
        /// Вторая замыкающая вершина.
        /// </summary>
        public uint Vertex2 { set; get; }

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

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Line()
        {
            LineID = LineIDGenerator.Source.nextId();
        }

        /// <summary>
        /// Возвращает тип объекта.
        /// </summary>
        public override string PrimitiveType => "Line";

        /// <summary>
        /// Обнаруживает замыкающие вершины и заполняет соответствующие свойства объекта Line.
        /// </summary>
        /// <param name="vertexes"></param>
        public void DetectAndFillTrailingVertices(List<Vertex> vertexes)
        {
            if (Points.Count() >= 2)
            {
                // Получим первую и последнюю точку линии.
                var vertex1 = Points.First();
                var vertex2 = Points.Last();

                // Получим замыкающие вершины. Идентификатор VertexID реального объекта не может быть 0.
                var result1 = vertexes.FirstOrDefault(n => n.X == vertex1.X && n.Y == vertex1.Y).VertexID;
                var result2 = vertexes.FirstOrDefault(n => n.X == vertex2.X && n.Y == vertex2.Y).VertexID;

                // Сохраним вершины либо поднимем исключение.
                if (result1 != 0 && result2 != 0)
                {
                    Vertex1 = result1;
                    Vertex2 = result2;
                }
                else
                {
                    throw new ArgumentNullException($"Метод DetectAndFillTrailingVertices не обнаружил замыкающую вершину для объекта Line.LineID = {LineID}.");
                }
            }
            else
            {
                throw new ArgumentNullException($"Метод DetectAndFillTrailingVertices не обнаружил достаточное количество объектов Point в объекте Line.LineID = {LineID}.");
            }
        }
    }
}
