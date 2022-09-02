using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphDFS
    {
        /// <summary>
        /// Список обнаруженных циклов в виде строк.
        /// </summary>
        private List<string> catalogCycles = new List<string>();

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
        private void DFScycle(int startVertex, int endV, List<GraphEdge> edges, int[] color, int unavailableEdge, List<int> cycle)
        {

            if (startVertex != endV)
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

                for (int i = 0; i < catalogCycles.Count; i++)
                {
                    if (catalogCycles[i].ToString() == s)
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

                    catalogCycles.Add(s);
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
                    DFScycle(edges[w].Vertex2, endV, edges, color, w, cycleNEW);
                    color[edges[w].Vertex2] = 1;
                }
                else if (color[edges[w].Vertex1] == 1 && edges[w].Vertex2 == startVertex)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(edges[w].Vertex1);
                    DFScycle(edges[w].Vertex1, endV, edges, color, w, cycleNEW);
                    color[edges[w].Vertex1] = 1;
                }
            }
        }

        /// <summary>
        /// Исключить циклы с одинаковыми вершинами.
        /// </summary>
        private void ExcludeCyclesWithTheSameVertices()
        {
            foreach(var cycle in Cycles)
            {
                cycle.RemoveAt(cycle.Count - 1);
            }

            List<List<int>> сyclesForExclude = new List<List<int>>();

            for (var i = 0; i < Cycles.Count; i++)
            {
                var cycle = Cycles[i];
                var k = i;
                k++;

                for (var j = k; j < Cycles.Count; j++)
                {
                    var cycleTest = Cycles[j];

                    if (cycle.Count != cycleTest.Count)
                    {
                        continue;
                    }

                    foreach(var vertex in cycle)
                    {
                        if (!cycleTest.Any(x => x == vertex))
                        {
                            break;
                        }

                        
                    }

                    сyclesForExclude.Add(cycleTest);
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
        public void ClearLists()
        {
            Verteces.Clear();
            Edges.Clear();
            Cycles.Clear();
            catalogCycles.Clear();
        }

        /// <summary>
        /// Метод для поиска всех циклов в графе. 
        /// </summary>
        public void CyclesSearch()
        {
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

            ExcludeCyclesWithTheSameVertices();
        }
    }
}
