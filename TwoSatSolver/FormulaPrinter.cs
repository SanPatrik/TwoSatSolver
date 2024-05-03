using System;
using System.Collections.Generic;

namespace TwoSatSolver
{
    public class FormulaPrinter
    {
        public void PrintFormula(List<(int, int)> clauses, Dictionary<int, bool> boolValues)
        {
            Console.WriteLine("Assigned Formula:");
            foreach (var (l1, l2) in clauses)
            {
                var part1 = FormatLiteral(l1, boolValues);
                var part2 = FormatLiteral(l2, boolValues);
                Console.WriteLine($"({part1} v {part2})");
            }
        }

        private string FormatLiteral(int literal, Dictionary<int, bool> boolValues)
        {
            bool isPositive = literal > 0;
            int index = Math.Abs(literal);
            bool value = isPositive ? boolValues[index] : !boolValues[index];
            return $"{(isPositive ? "" : "¬")}x{index}={value}";
        }
    }
}