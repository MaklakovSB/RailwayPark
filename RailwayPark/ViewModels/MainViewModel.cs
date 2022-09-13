using Graph;
using RailwayPark.Delegates;
using RailwayPark.Enums;
using RailwayPark.Factory;
using RailwayPark.Interfaces;
using RailwayPark.Models;
using RailwayPark.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RailwayPark.ViewModels
{
    public class MainViewModel : IViewModel, INotifyPropertyChanged
    {
        #region Свойства и поля

        /// <summary>
        /// Экземпляр объекта граф.
        /// </summary>
        private GraphDFS graph = new GraphDFS();

        /// <summary>
        /// Циклы будущих регионов.
        /// </summary>
        private List<List<int>> regonsCycle = new List<List<int>>();

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

        /// <summary>
        /// Коллекция LineItems.
        /// </summary>
        public ObservableCollection<Line> LineItems
        {
            get
            {
                return lineItems;
            }
        }
        private ObservableCollection<Line> lineItems = new ObservableCollection<Line>();

        /// <summary>
        /// Коллекция AreaItems.
        /// </summary>
        public ObservableCollection<Area> AreaItems
        {
            get
            {
                return areaItems;
            }
        }
        private ObservableCollection<Area> areaItems = new ObservableCollection<Area>();

        /// <summary>
        /// Выбранная линия для смены визуального состояния.
        /// </summary>
        public Line SelectedLineItem
        {
            get
            {
                return selectedLineItem;
            }

            set
            {
                selectedLineItem = value;
                OnPropertyChanged(nameof(SelectedLineItem));
            }
        }
        private Line selectedLineItem;

        /// <summary>
        /// Выбранный регион для заливки.
        /// </summary>
        public Area SelectedAreaItem
        {
            get
            {
                return selectedAreaItem;
            }

            set
            {
                selectedAreaItem = value;
                OnPropertyChanged(nameof(SelectedAreaItem));
            }
        }
        private Area selectedAreaItem;

        #endregion

        #region Команды

        /// <summary>
        /// Смена цвета для выбранного региона.
        /// </summary>
        public ICommand CangeColorCommand
        {
            get
            {
                if (cangeColorCommand == null)
                {
                    cangeColorCommand = new DelegateCommand(CangeColor);
                }

                return cangeColorCommand;
            }
        }
        private ICommand cangeColorCommand;

        /// <summary>
        /// Обесцвечивание области.
        /// </summary>
        public ICommand TransparentColorCommand
        {
            get
            {
                if (transparentColorCommand == null)
                {
                    transparentColorCommand = new DelegateCommand(TransparentColor);
                }

                return transparentColorCommand;
            }
        }
        private ICommand transparentColorCommand;

        /// <summary>
        /// Смена визуального состояния линии.
        /// </summary>
        public ICommand CangeVisibilityCommand
        {
            get
            {
                if (cangeVisibilityCommand == null)
                {
                    cangeVisibilityCommand = new DelegateCommand(CangeVisibility);
                }

                return cangeVisibilityCommand;
            }
        }
        private ICommand cangeVisibilityCommand;

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
            // Сбросить счётчики идентификаторов.
            VertexIDGenerator.Source.ResetCounter();
            LineIDGenerator.Source.ResetCounter();
            AreaIDGenerator.Source.ResetCounter();

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
            points.Add(new Point(470, 80));
            PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            points.Clear();

            points.Add(new Point(470, 80));
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

            //// Тест метода DetectAndFillTrailingVertices
            //// Линия не имеющая замыкающих вершин должна вызвать исключение.
            ////points.Add(new Point(450.5, 100.5));
            ////points.Add(new Point(460.5, 90.5));
            ////PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Line, 0, 0, 1, points, verteces));
            ////points.Clear();

            // Добавим линии в список для ComboBox'а выбора линии для смены визуального состояния.
            var onlyLines = PirmitiveItems.OfType<Line>().ToList();

            foreach (var line in onlyLines)
            {
                LineItems.Add(line);
            }

            // найти замкнутые области.
            FindEnclosedAreasOfPrimitives();
        }

        /// <summary>
        /// Найти замкнутые области примитивов.
        /// </summary>
        private void FindEnclosedAreasOfPrimitives()
        {
            // Получаем линии и вершины отдельными списками.
            var lines = PirmitiveItems.OfType<Line>().ToList();
            var verteces = PirmitiveItems.OfType<Vertex>().ToList();

            // Заполним граф вершинами.
            foreach(var vertex in verteces)
            {
                graph.Verteces.Add(new GraphVertex(vertex.X, vertex.Y));
            }

            // Заполним граф гранями.
            foreach (var line in lines)
            {
                graph.Edges.Add(new GraphEdge(line.Vertex1, line.Vertex2));
            }

            // Находим циклы.
            graph.CyclesSearch();

            // Скопируем циклы.
            regonsCycle.Clear();
            foreach(var cycle in graph.Cycles)
            {
                var nc = new List<int>();
                foreach(var vertex in cycle)
                {
                    nc.Add(vertex);
                }
                regonsCycle.Add(nc);
            }

            graph.ClearAllLists();

            CreatingEnclosedRegionPrimitives();
        }

        /// <summary>
        /// Создание примитивов замкнутых областей
        /// </summary>
        private void CreatingEnclosedRegionPrimitives()
        {
            if(regonsCycle.Count == 0)
            {
                return;
            }

            var lines = PirmitiveItems.OfType<Line>().ToList();
            var searchedListsPoints = new List<List<List<Point>>>();


            // Проход по всем циклам, каждый из которых станет замкнутым регионом.
            foreach (var cycle in regonsCycle)
            {
                // Списки точек - один список-списков соответствует одному региону.
                var ListsPoints = new List<List<Point>>();

                // Проход по идентификаторам вершин одного цикла.
                for (int i = 0; i < cycle.Count ; i++)
                {
                    // Сначала получим пару идентификаторов вершин соответствующих
                    // началу и концу возможно ломаной линий, чтобы найти объект Line
                    // соответствующий части цикла.
                    var vertex1 = cycle[i];
                    int vertex2;

                    // Если не последняя итерация,
                    // то вторая вершина следующая по списку,
                    // иначе - первая в списке.
                    if ((i + 1) < cycle.Count)
                    {
                        vertex2 = cycle[i + 1];
                    }
                    else
                    {
                        vertex2 = cycle[0];
                    }

                    // Будем копировать точки линии в из списка pointsFrom в список pointsIn.
                    var pointsFrom = new List<Point>();
                    var pointsIn = new List<Point>();

                    // Пытаемся найти линию.
                    var line = lines.FirstOrDefault(x => x.Vertex1 == vertex1 && x.Vertex2 == vertex2);
                    
                    if(line == null)
                    {
                        // Если линия не нашлась, то ищем в обратном порядке вершин.
                        line = lines.FirstOrDefault(x => x.Vertex1 == vertex2 && x.Vertex2 == vertex1);

                        if (line == null)
                        {
                            throw new Exception("CreatingEnclosedRegionPrimitives");
                        }

                        // Берём список Point в обратном порядке.
                        pointsFrom = line.Points.Reverse().ToList<Point>();
                    }
                    else
                    {
                        // Берём список Point в прямом порядке.
                        pointsFrom = line.Points.ToList<Point>();
                    }

                    // Копируем список Point с созданием новых экземпляров.
                    foreach (var point in pointsFrom)
                    {
                        pointsIn.Add(new Point(point.X, point.Y));
                    }

                    // Заносим список точек одного ребра в список-списков точек.
                    ListsPoints.Add(pointsIn);
                }

                // Заносим список-списков точек в список в соответствующий регионам.
                searchedListsPoints.Add(ListsPoints);
            }

            foreach(var region in searchedListsPoints)
            {
                List<Point> regp = new List<Point>();

                for (var j = 0; j < region.Count; j++)
                {
                    var edge = region[j];
                    
                    for (var i = 0; i < edge.Count - 1 ; i++)
                    {
                        regp.Add(edge[i]);

                        if((edge.Count - 1) == i)
                        {
                            regp.Add(edge[i+1]);
                        }

                    }
                }

                var closed = new Point(regp.First().X, regp.First().Y);
                regp.Add(closed);

                PirmitiveItems.Add(PrimitiveFactory.GetBasePrimitive(PrimitiveEnum.Area, 0, 0, 2, regp));
            }

            var newAreas = PirmitiveItems.OfType<Area>().ToList();

            foreach(var area in newAreas)
            {
                AreaItems.Add(area);
            }
        }

        /// <summary>
        /// Метод смены цвета областей.
        /// </summary>
        private void CangeColor()
        { 
            if(SelectedAreaItem != null)
            {
                SelectedAreaItem.Fill = SelectedFillColor;
            }
        }

        /// <summary>
        /// Метод обесцвечивания областей.
        /// </summary>
        private void TransparentColor()
        {
            if (SelectedAreaItem != null)
            {
                SelectedAreaItem.Fill = Brushes.Transparent.Color;
            }
        }

        /// <summary>
        /// Метод смены визуального состояния выбранной линии.
        /// </summary>
        private void CangeVisibility()
        {
            if(SelectedLineItem != null)
            {
                if (SelectedLineItem.Visibility == Visibility.Visible)
                {
                    SelectedLineItem.Visibility = Visibility.Hidden;
                }
                else if(SelectedLineItem.Visibility == Visibility.Hidden)
                {
                    SelectedLineItem.Visibility = Visibility.Visible;
                }
            }
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
