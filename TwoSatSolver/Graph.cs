using System.Collections.Generic;

namespace TwoSatSolver
{
    public class Graph
    {
        private readonly Dictionary<int, List<int>> _edges = new Dictionary<int, List<int>>();

        public Graph(int vertices)
        {
            for (int i = 1; i <= vertices; i++)
            {
                _edges.Add(i, new List<int>());
                _edges.Add(-i, new List<int>());
            }
        }


        public void AddEdge(int from, int to)
        {
            _edges[from].Add(to);
        }

        public IEnumerable<int> GetEdges(int vertex)
        {
            return _edges[vertex];
        }

        public IEnumerable<int> Vertices => _edges.Keys;
    }
}