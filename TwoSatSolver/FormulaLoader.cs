using System;
using System.Collections.Generic;
using System.IO;

namespace TwoSatSolver
{
    public class FormulaLoader
    {
        public (int, List<(int, int)>, string) LoadFormulaFromFile(string fileName)
        {
            int numVariables = 0;
            int numClauses = 0;
            var clauses = new List<(int, int)>();
            string formulaString = "";

            using (var reader = new StreamReader(fileName))
            {
                // Parse the first line to get the number of variables and clauses
                var firstLine = reader.ReadLine();
                var parts = firstLine.Split();
                numVariables = int.Parse(parts[0]);
                numClauses = int.Parse(parts[1]);

                // Read each subsequent line, which represents a clause
                for (int i = 0; i < numClauses; i++)
                {
                    var line = reader.ReadLine();
                    var numbers = Array.ConvertAll(line.Trim().Split(), int.Parse);
                    var list = new List<int>(numbers);
                    list.RemoveAll(item => item == 0);  // Remove the terminating '0' from the list

                    // Check for correct number of literals
                    if (list.Count == 1)
                    {
                        // If there's only one literal, use it twice (self-clause)
                        clauses.Add((list[0], list[0]));
                        formulaString += BuildFormula(list[0], list[0]) + " ∧ ";
                    }
                    else if (list.Count == 2)
                    {
                        clauses.Add((list[0], list[1]));
                        formulaString += BuildFormula(list[0], list[1]) + " ∧ ";
                    }
                    else
                    {
                        throw new ArgumentException("Invalid clause with incorrect number of literals.");
                    }
                }
            }
            formulaString = formulaString.TrimEnd(' ', '∧');  // Remove trailing " ∧ "
            return (numVariables, clauses, formulaString);
        }

        private string BuildFormula(int l1, int l2)
        {
            return $"({LiteralString(l1)} v {LiteralString(l2)})";
        }

        private string LiteralString(int literal)
        {
            return literal > 0 ? $"x{literal}" : $"¬x{-literal}";
        }
    }
}
