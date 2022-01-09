using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackgroundProcessing
{
    public class Calculate
    {
        public static Int64 GetSum(List<state> states)
        {
            Int64 populationSum = 0;

            states
                .ForEach(s => populationSum += s.attributes.POPULATION);

            return populationSum;
        }

        public static List<string> GetStateNames(List<state> states)
        {
            var stateNames = new List<string>();

            foreach (var state in states)
            {
                if(stateNames.Contains(state.attributes.STATE_NAME) == false)
                {
                    stateNames.Add(state.attributes.STATE_NAME);
                }
            }
            return stateNames;
        }

        public static Int64 GetStatePopulation(List<state> stateData, string stateName)
        {
            var statePopulation =
                GetSum(stateData
               .Where(s => s.attributes.STATE_NAME == stateName)
               .ToList());

            return statePopulation;
        }

        public static List<string> GetStatistics(List<state> stateData)
        {
            var result = new List<string>();
            var stateNames = GetStateNames(stateData);

            result.Add(DateTime.Now.ToString());

            foreach (var stateName in stateNames)
            {
                var statePopulation = GetStatePopulation(stateData, stateName);
                var stateRow = new StringBuilder();
                stateRow.Append(stateName);
                stateRow.Append(",");
                stateRow.Append(statePopulation.ToString());

                //Console.WriteLine(stateRow);
                result.Add(stateRow.ToString());
            }

            return result;
        }
    }
}
