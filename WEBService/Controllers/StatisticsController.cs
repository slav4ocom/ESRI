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
        //static string format = "";
        static string state = "";

        public StatisticsController()
        {
            DecodeOptions();
            var lines = File.ReadAllLines("../../../../statistics.txt");
            var result = lines.FirstOrDefault(l => l.Contains(state));

            if (result != null)
            {
                var resultState = result.Split(",").First();
                var resultPopulation = long.Parse(result.Split(",").Last());
                if (format == "json")
                {
                    var s = new StateResult()
                    {
                        lastUpdated = lines[0],
                        STATE_NAME = resultState,
                        POPULATION = resultPopulation,
                        error = null
                    };
                    html = JsonSerializer.Serialize(s, new JsonSerializerOptions() { WriteIndented = true });
                }
                else
                {
                    html = result;
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
                    html = JsonSerializer.Serialize(s, new JsonSerializerOptions() { WriteIndented = true });
                }
                else
                {
                    html = "<b>state not found</b>";
                }
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
