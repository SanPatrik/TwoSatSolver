using System;

namespace TwoSatSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet TwoSatSolver <filename>");
                return;
            }
            string fileName = args[0];
            var formulaLoader = new FormulaLoader();
            var (nVar, clauses, formulaString) = formulaLoader.LoadFormulaFromFile(fileName);
            Console.WriteLine(formulaString);
            var graphBuilder = new GraphBuilder();
            var (graph, inverseGraph) = graphBuilder.BuildGraph(nVar, clauses);
            var sccFinder = new SccFinder();
            var components = sccFinder.FindScc(graph, inverseGraph);
            var solver = new SatSolver();

            if (solver.IsSatisfiable(components))
            {
                var boolValues = solver.GetBoolValues(components, nVar);
                foreach (var value in boolValues)
                {
                    Console.WriteLine(value.Value ? "PRAVDA" : "NEPRAVDA");
                }
            }
        }

    }
}