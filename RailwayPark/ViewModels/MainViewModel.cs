using Graph;
using RailwayPark.Interfaces;
using RailwayPark.Models;
using System;
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
            PirmitiveItems.Add(new Vertex() { X = 0,   Y = 40, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 140, Y = 130, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 600, Y = 80, Z = 2 });

            // Остальные точки по тз.
            PirmitiveItems.Add(new Vertex() { X = 40,  Y = 30, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 50,  Y = 40, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 450, Y = 40, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 60,  Y = 50, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 70,  Y = 60, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 500, Y = 60, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 450, Y = 60, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 80,  Y = 70, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 90,  Y = 80, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 470, Y = 80, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 450, Y = 80, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 520, Y = 80, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 100, Y = 90, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 220, Y = 90, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 460, Y = 90, Z = 2 });
            PirmitiveItems.Add(new Vertex() { X = 450, Y = 100, Z = 2 });

            // Линии.
            var line = new Line() { Z = 1 };
            line.Points.Add(new Point(0, 40));
            line.Points.Add(new Point(10, 30));
            line.Points.Add(new Point(40, 30));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(100, 90));
            line.Points.Add(new Point(140, 130));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(520, 80));
            line.Points.Add(new Point(600, 80));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(40, 30));
            line.Points.Add(new Point(440, 30));
            line.Points.Add(new Point(450, 40));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(450, 40));
            line.Points.Add(new Point(50, 40));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(50, 40));
            line.Points.Add(new Point(40, 30));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(450, 40));
            line.Points.Add(new Point(480, 40));
            line.Points.Add(new Point(500, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(500, 60));
            line.Points.Add(new Point(450, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(450, 60));
            line.Points.Add(new Point(440, 50));
            line.Points.Add(new Point(60, 50));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(60, 50));
            line.Points.Add(new Point(50, 40));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(60, 50));
            line.Points.Add(new Point(70, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(70, 60));
            line.Points.Add(new Point(450, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(80, 70));
            line.Points.Add(new Point(440, 70));
            line.Points.Add(new Point(450, 80));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(80, 70));
            line.Points.Add(new Point(70, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(450, 80));
            line.Points.Add(new Point(520, 80));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(520, 80));
            line.Points.Add(new Point(500, 60));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(90, 80));
            line.Points.Add(new Point(450, 80));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(90, 80));
            line.Points.Add(new Point(80, 70));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(470, 80));
            line.Points.Add(new Point(460, 90));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(460, 90));
            line.Points.Add(new Point(220, 90));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(220, 90));
            line.Points.Add(new Point(100, 90));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(100, 90));
            line.Points.Add(new Point(90, 80));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(220, 90));
            line.Points.Add(new Point(230, 100));
            line.Points.Add(new Point(450, 100));
            PirmitiveItems.Add(line);

            line = new Line() { Z = 1 };
            line.Points.Add(new Point(450, 100));
            line.Points.Add(new Point(460, 90));
            PirmitiveItems.Add(line);

            // Получаем линии и вершины отдельными списками.
            var Lines = PirmitiveItems.OfType<Line>().ToList();
            var Vertexes = PirmitiveItems.OfType<Vertex>().ToList();

            // Находим вершины для всех линий.
            foreach (var currentline in Lines)
            {
                currentline.DetectAndFillTrailingVertices(Vertexes);
            }

        }

        /// <summary>
        /// Найти замкнутые области примитивов.
        /// </summary>
        private void FindEnclosedAreasOfPrimitives()
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
