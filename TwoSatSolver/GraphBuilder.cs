using System.Collections.Generic;

namespace TwoSatSolver
{
    public class GraphBuilder
    {
        public (Graph, Graph) BuildGraph(int nVar, List<(int, int)> clauses)
        {
            var graph = new Graph(nVar * 2);
            var invGraph = new Graph(nVar * 2);

            foreach (var (l1, l2) in clauses)
            {
                graph.AddEdge(-l1, l2);
                graph.AddEdge(-l2, l1);
                invGraph.AddEdge(l2, -l1);
                invGraph.AddEdge(l1, -l2);
            }

            return (graph, invGraph);
        }
    }
}