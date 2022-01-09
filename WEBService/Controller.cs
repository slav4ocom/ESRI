using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBService
{
    public static class Controller
    {
        const string NL = "\r\n";
        static string requestURLString = "";
        static string[] requestParts = new string[4];
        static string requestType = "";
        static string controller = "";
        static string action = "";
        static string options = "";

        static string format = "";
        static string state = "";
        public static string MainController(string requestURL)
        {
            requestURLString = requestURL;
            requestParts = requestURLString.Split("/");
            requestType = requestParts[0];

            if (requestParts.Length > 1)
            {
                controller = requestParts[1];
            }

            if (requestParts.Length > 2)
            {
                action = requestParts[2];
            }
            else
            {
                action = "<b>none</b>";
            }

            if (requestParts.Length > 3)
            {
                options = requestParts[3];
            }
            else
            {
                options = "<b>none</b>";
            }


            string html = $"<h3>ESRI REST API {DateTime.Now}</h3>" + NL
                + requestURL + NL + "<br/>"
                + "request type: " + requestType + NL + "<br/>"
                + "controller: " + controller + NL + "<br/>"
                + "action: " + action + NL + "<br/>"
                + "options:" + options + NL;

            string response = "HTTP/1.1 200 OK" + NL
                + "Server: slav4o.com " + NL
                + "Content-Type: " + GetContentType() + NL
                //+ "Content-Type: text/html; charset=utf-8" + NL
                + "Content-Length: " + html.Length + NL
                + NL
                + html + NL;


            return response;
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
                    var pair = part.Split("=",StringSplitOptions.RemoveEmptyEntries);
                    requestPairs.Add(pair[0], pair[1]);
                }
            }
            catch(Exception e)
            {

            }

            if (requestPairs.ContainsKey("state"))
            {
                state = requestPairs["state"].Trim();
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
        private static string GetContentType()
        {
            DecodeOptions();
            var result = "text/html; charset=utf-8";
            if(format == "json")
            {
                result = "text/json; charset=utf-8";
            }

            return result;
        }
    }
}