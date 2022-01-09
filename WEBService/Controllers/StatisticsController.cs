using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using WEBService.Models;
using static WEBService.Controller;

namespace WEBService.Controllers
{
    public class StatisticsController
    {
        static string state = "";
        static string[] lines;
        private string ReturnStateData(string currentState)
        {
            var result = "";
            //var lines = File.ReadAllLines("../../../../statistics.csv");
            var stateRow = lines.FirstOrDefault(l => l.Contains(currentState));

            if (stateRow != null)
            {
                var resultState = stateRow.Split(",").First();
                var resultPopulation = long.Parse(stateRow.Split(",").Last());
                if (format == "json")
                {
                    var s = new StateResult()
                    {
                        lastUpdated = lines[0],
                        STATE_NAME = resultState,
                        POPULATION = resultPopulation,
                        error = null
                    };
                    result = JsonSerializer.Serialize(s, new JsonSerializerOptions() { WriteIndented = true });
                }
                else
                {
                    result = $"<b>state name </b>{resultState}<br/><b>population</b> {resultPopulation.ToString()}<br/><b>last updated </b>{lines[0].ToString()}";
                }
            }
            else
            {
                if (format == "json")
                {
                    var s = new StateResult
                    {
                        error = "state not found"
                    };
                    result = JsonSerializer.Serialize(s, new JsonSerializerOptions() { WriteIndented = true });
                }
                else
                {
                    result = "<b>state not found</b>";
                }
            }

            return result;
        }


        private List<string> GetStatesNames()
        {
            var result = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                result.Add(lines[i].Split(",").First());
            }
            return result;
        }
        public StatisticsController()
        {
            DecodeOptions();

            lines = File.ReadAllLines("../../../../statistics.csv");

            if (state == "")
            {
                //html = "no state specified.";
                var stateNames = GetStatesNames();

                stateNames
                    .ForEach(s => html += ReturnStateData(s));
            }
            else
            {
                html = ReturnStateData(state);
            }


        }

        private static void DecodeOptions()
        {
            var last = requestParts[requestParts.Length - 1];
            var lastParts = last.Split("&").ToList();

            var requestPairs = new Dictionary<string, string>();

            try
            {
                foreach (var part in lastParts)
                {
                    var pair = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    requestPairs.Add(pair[0], pair[1]);
                }
            }
            catch (Exception e)
            {

            }

            if (requestPairs.ContainsKey("state"))
            {
                state = requestPairs["state"].Trim();
                state = System.Net.WebUtility.UrlDecode(state);
            }
            else
            {
                state = "";
            }

            if (requestPairs.ContainsKey("format"))
            {
                format = requestPairs["format"].Trim();
            }
            else
            {
                format = "";
            }

        }

    }
}
