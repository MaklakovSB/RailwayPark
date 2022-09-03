using Graph;
using RailwayPark.Enums;
using RailwayPark.Factory;
using RailwayPark.Interfaces;
using RailwayPark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
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
            private get
            {
                return selectedFillColor;
            }
            set
            {
                selectedFillColor = value;
                OnPropertyChanged(nameof(SelectedFillColor));
            }
        }
        private Color selectedFillColor = Brushes.LightGoldenrodYellow.Color;

        /// <summary>
        /// Коллекция примитивов для отрисовки.
        /// </summary>
        public ObservableCollection<BasePrimitive> PirmitiveItems 
        { 
            get { return pirmitiveItems; }
        }
        private ObservableCollection<BasePrimitive> pirmitiveItems = new ObservableCollection<BasePrimitive>();

        #endregion

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            // Инициализируем коллекцию исходными данными.
            InitialData();
        }

        /// <summary>
        /// Инициализирует исходные данные.
        /// </summary>
        private void InitialData()
        {
            // Добавление примитивов.

            // Дополненые точки.
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 0, 40, 2));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 140, 130, 2));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 600, 80, 2));

            // Остальные точки по тз.
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 40, 30, 2));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 50, 40, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 450, 40, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 60, 50, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 70, 60, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 500, 60, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 450, 60, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 80, 70, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 90, 80, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 470, 80, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 450, 80, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 520, 80, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 100, 90, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 220, 90, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 460, 90, 2 ));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Vetex, 450, 100, 2 ));

            // Линии.
            var verteces = PirmitiveItems.OfType<Vertex>().ToList();
            var points = new List<Point>();

            points.Add(new Point(0, 40));
            points.Add(new Point(10, 30));
            points.Add(new Point(40, 30));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(100, 90));
            points.Add(new Point(140, 130));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(520, 80));
            points.Add(new Point(600, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(40, 30));
            points.Add(new Point(440, 30));
            points.Add(new Point(450, 40));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(450, 40));
            points.Add(new Point(50, 40));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(50, 40));
            points.Add(new Point(40, 30));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(450, 40));
            points.Add(new Point(480, 40));
            points.Add(new Point(500, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(500, 60));
            points.Add(new Point(450, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(450, 60));
            points.Add(new Point(440, 50));
            points.Add(new Point(60, 50));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(60, 50));
            points.Add(new Point(50, 40));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(60, 50));
            points.Add(new Point(70, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(70, 60));
            points.Add(new Point(450, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(80, 70));
            points.Add(new Point(440, 70));
            points.Add(new Point(450, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(80, 70));
            points.Add(new Point(70, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(450, 80));
            points.Add(new Point(520, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(520, 80));
            points.Add(new Point(500, 60));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(90, 80));
            points.Add(new Point(450, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(90, 80));
            points.Add(new Point(80, 70));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(470, 80));
            points.Add(new Point(460, 90));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(460, 90));
            points.Add(new Point(220, 90));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(220, 90));
            points.Add(new Point(100, 90));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(100, 90));
            points.Add(new Point(90, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(220, 90));
            points.Add(new Point(230, 100));
            points.Add(new Point(450, 100));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(450, 100));
            points.Add(new Point(460, 90));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

        }

        /// <summary>
        /// Найти замкнутые области примитивов.
        /// </summary>
        private void FindEnclosedAreasOfPrimitives()
        {
            GraphDFS graph = new GraphDFS();

            // Получаем линии и вершины отдельными списками.
            var lines = PirmitiveItems.OfType<Line>().ToList();
            var verteces = PirmitiveItems.OfType<Vertex>().ToList();

            // Заполним граф вершинами.
            foreach(var vertex in verteces)
            {
                graph.Verteces.Add(new GraphVertex((int)vertex.X, (int)vertex.Y));
            }

            // Заполним граф гранями.
            foreach (var line in lines)
            {
                graph.Edges.Add(new GraphEdge((int)line.Vertex1, (int)line.Vertex2));
            }

            // Находим циклы.
            graph.CyclesSearch();

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
