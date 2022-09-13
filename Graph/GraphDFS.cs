using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphDFS
    {
        /// <summary>
        /// Список обнаруженных циклов в виде строк.
        /// </summary>
        private List<string> CatalogCycles = new List<string>();

        /// <summary>
        /// Список вершин.
        /// </summary>
        public List<GraphVertex> Verteces 
        { 
            get
            {
                return verteces;
            }
        }
        private List<GraphVertex> verteces = new List<GraphVertex>();

        /// <summary>
        /// Список ребер.
        /// </summary>
        public List<GraphEdge> Edges 
        { 
            get
            {
                return edges;
            }
        }
        private List<GraphEdge> edges = new List<GraphEdge>();

        /// <summary>
        /// Список обнаруженных циклов.
        /// </summary>
        public List<List<int>> Cycles
        {
            get
            {
                return сycles;
            }
        }
        private List<List<int>> сycles = new List<List<int>>();

        /// <summary>
        /// Поиск в глубину.
        /// </summary>
        private void DFScycle(int startVertex, int endVertex, List<GraphEdge> edges, int[] color, int unavailableEdge, List<int> cycle)
        {

            if (startVertex != endVertex)
            {
                color[startVertex] = 2;
            }
            else if (cycle.Count >= 2)
            {
                cycle.Reverse();
                string s = cycle[0].ToString();

                for (int i = 1; i < cycle.Count; i++)
                {
                    s += "-" + cycle[i].ToString();
                }

                bool palindromeFlag = false;

                for (int i = 0; i < CatalogCycles.Count; i++)
                {
                    if (CatalogCycles[i].ToString() == s)
                    {
                        palindromeFlag = true;
                        break;
                    }
                }

                if (!palindromeFlag)
                {
                    cycle.Reverse();
                    s = cycle[0].ToString();

                    List<int> ls = new List<int>();
                    ls.Add(cycle[0]);

                    for (int i = 1; i < cycle.Count; i++)
                    {
                        s += "-" + cycle[i].ToString();
                        ls.Add(cycle[i]);
                    }

                    CatalogCycles.Add(s);
                    Cycles.Add(ls);
                }

                return;
            }

            for (int w = 0; w < edges.Count; w++)
            {
                if (w == unavailableEdge)
                {
                    continue;
                }

                if (color[edges[w].Vertex2] == 1 && edges[w].Vertex1 == startVertex)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(edges[w].Vertex2);
                    DFScycle(edges[w].Vertex2, endVertex, edges, color, w, cycleNEW);
                    color[edges[w].Vertex2] = 1;
                }
                else if (color[edges[w].Vertex1] == 1 && edges[w].Vertex2 == startVertex)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(edges[w].Vertex1);
                    DFScycle(edges[w].Vertex1, endVertex, edges, color, w, cycleNEW);
                    color[edges[w].Vertex1] = 1;
                }
            }
        }

        /// <summary>
        /// Исключить циклы с одинаковыми вершинами.
        /// </summary>
        private void ExcludeCyclesWithTheSameVertices()
        {
            List<List<int>> сyclesForExclude = new List<List<int>>();
            List<bool> usedSign = new List<bool>();

            for(var b = 0; b < Cycles.Count; b++)
            {
                usedSign.Add(false);
            }

            for (var i = 0; i < Cycles.Count; i++)
            {
                var cycle = Cycles[i];

                if (usedSign[i] == true)
                {
                    continue;
                }

                for (var j = i + 1; j < Cycles.Count; j++)
                {
                    var equ = true;

                    if (usedSign[j] == true)
                    {
                        continue;
                    }

                    var cycleTest = Cycles[j];

                    if (cycle.Count != cycleTest.Count)
                    {
                        continue;
                    }

                    for(var m = 0; m < cycle.Count; m++)
                    {
                        var vertex = cycle[m];
                        if (!cycleTest.Any(x => x == vertex))
                        {
                            equ = false;
                            break;
                        }
                    }

                    // Необходимо исследовать причину того, что оператор break
                    // в данной ситуации не прерывал цикл, а срабатывал
                    // как Continue т.е. переходил к следующей итерации!!!
                    //foreach(var vertex in cycle)
                    //{
                    //    if (!cycleTest.Any(x => x == vertex))
                    //    {
                    //        break;
                    //    }
                    //}

                    if (equ)
                    {
                        usedSign[j] = true;
                        сyclesForExclude.Add(cycleTest);
                    }
                }
            }

            foreach(var cycleForExclude in сyclesForExclude)
            {
                Cycles.Remove(cycleForExclude);
            }
        }

        /// <summary>
        /// Очистка списков.
        /// </summary>
        public void ClearAllLists()
        {
            Verteces.Clear();
            Edges.Clear();
            Cycles.Clear();
            CatalogCycles.Clear();
        }

        /// <summary>
        /// Метод для поиска всех циклов в графе. 
        /// </summary>
        public void CyclesSearch()
        {
            // Найти все циклы.
            int[] color = new int[Verteces.Count];
            for (int i = 0; i < Verteces.Count; i++)
            {
                for (int k = 0; k < Verteces.Count; k++)
                {
                    color[k] = 1;
                }

                List<int> cycle = new List<int>();
                cycle.Add(i);
                DFScycle(i, i, Edges, color, -1, cycle);
            }

            // Удалить последнюю вершину совпадающую с первой у всех циклов.
            foreach (var cycle in Cycles)
            {
                cycle.RemoveAt(cycle.Count - 1);
            }

            // Исключить повторяющиеся лишние циклы.
            ExcludeCyclesWithTheSameVertices();

            // Очистить исходные списки.
            CatalogCycles.Clear();
            Verteces.Clear();
            Edges.Clear();
        }
    }
}
