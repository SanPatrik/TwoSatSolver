using System;
using System.Collections.Generic;

namespace TwoSatSolver
{
    public class SatSolver
    {
        public bool IsSatisfiable(Dictionary<int, int> components)
        {
            foreach (var key in components.Keys)
            {
                if (key > 0 && components.ContainsKey(-key))
                {
                    if (components[key] == components[-key])
                    {
                        Console.WriteLine("NESPLNITEĽNÁ");
                        return false;
                    }
                }
            }
            Console.WriteLine("SPLNITEĽNÁ");
            return true;
        }

        public Dictionary<int, bool> GetBoolValues(Dictionary<int, int> components, int numVariables)
        {
            var boolValues = new Dictionary<int, bool>();
            for (int i = 1; i <= numVariables; i++)
            {
                int positiveIndex = i;
                int negativeIndex = -i;

                // Check if the components for the positive and negative indices exist in the dictionary
                // Note: It's crucial to handle cases where the component might not exist for a negative or positive literal
                int componentPositive = components.ContainsKey(positiveIndex) ? components[positiveIndex] : int.MinValue;
                int componentNegative = components.ContainsKey(negativeIndex) ? components[negativeIndex] : int.MinValue;

                // Assign true if the component number of the positive literal is greater than that of the negative literal
                boolValues[i] = componentPositive > componentNegative;
            }
            return boolValues;
        }


    }
}