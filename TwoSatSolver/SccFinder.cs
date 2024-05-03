using System;
using System.Collections.Generic;

namespace TwoSatSolver
{
    public class SccFinder
    {
        public Dictionary<int, int> FindScc(Graph graph, Graph inverseGraph)
        {
            // First step: order vertices based on finishing times in decreasing order
            var visited = new HashSet<int>();
            var finishOrder = new Stack<int>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    FillOrder(graph, vertex, visited, finishOrder);
                }
            }

            // Second step: process the reversed graph based on the finish order
            var components = new Dictionary<int, int>();
            visited.Clear();
            int componentId = 0;

            while (finishOrder.Count > 0)
            {
                var vertex = finishOrder.Pop();
                if (!visited.Contains(vertex))
                {
                    ProcessOrder(inverseGraph, vertex, visited, components, componentId);
                    componentId++;
                }
            }

            return components;
        }

        private void FillOrder(Graph graph, int vertex, HashSet<int> visited, Stack<int> finishOrder)
        {
            visited.Add(vertex);
            foreach (var neighbor in graph.GetEdges(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    FillOrder(graph, neighbor, visited, finishOrder);
                }
            }
            finishOrder.Push(vertex);
        }

        private void ProcessOrder(Graph graph, int vertex, HashSet<int> visited, Dictionary<int, int> components, int componentId)
        {
            visited.Add(vertex);
            components[vertex] = componentId;

            foreach (var neighbor in graph.GetEdges(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    ProcessOrder(graph, neighbor, visited, components, componentId);
                }
            }
        }
    }
}
