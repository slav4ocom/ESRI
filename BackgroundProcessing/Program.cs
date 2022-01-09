using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace BackgroundProcessing
{
    class Program
    {
        const string serviceString = "https://services.arcgis.com/P3ePLMYs2RVChkJx/ArcGIS/rest/services/USA_Counties/FeatureServer/0/query?where=1%3D1&outFields=population%2C+state_name&returnGeometry=false&f=pjson";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(serviceString);
            StreamReader reader = new StreamReader(data);
            string jsonData = reader.ReadToEnd();
            //Console.WriteLine(jsonData);

            var result = JsonSerializer.Deserialize<response>(jsonData);

            var stateData = result.features;

            var statistics = Calculate.GetStatistics(stateData);

            statistics
                .ForEach(Console.WriteLine);

            var fileName = "../../../../statistics.csv";
            
            File.WriteAllLines(fileName, statistics);

            data.Close();
            reader.Close();
        }
    }
}
