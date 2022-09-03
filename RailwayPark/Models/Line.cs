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
        public int LineID { private set; get; }

        /// <summary>
        /// Первая замыкающая вершина.
        /// </summary>
        public int Vertex1 { set; get; }

        /// <summary>
        /// Вторая замыкающая вершина.
        /// </summary>
        public int Vertex2 { set; get; }

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
        /// <param name="verteces"></param>
        public void DetectAndFillTrailingVertices(List<Vertex> verteces)
        {
            if (Points.Count() >= 2)
            {
                // Получим первую и последнюю точку линии.
                var vertex1 = Points.First();
                var vertex2 = Points.Last();

                // Получим замыкающие вершины. Идентификатор VertexID реального объекта не может быть 0.
                var result1 = verteces.FirstOrDefault(n => n.X == vertex1.X && n.Y == vertex1.Y);
                var result2 = verteces.FirstOrDefault(n => n.X == vertex2.X && n.Y == vertex2.Y);

                // Сохраним вершины либо поднимем исключение.
                if (result1 != null || result2 != null)
                {
                    Vertex1 = result1.VertexID;
                    Vertex2 = result2.VertexID;
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
