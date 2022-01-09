using System;
using System.Collections.Generic;
using System.Text;

namespace WEBService
{
    public static class Controller
    {
        const string NL = "\r\n";
        public static string MainController(string requestURL)
        {
            var requestParts = requestURL.Split("/");
            var requestType = requestParts[0];
            var controller = "";
            var action = "";
            var options = "";

            if (requestParts.Length > 1)
            {
                controller = requestParts[1];
            }

            if (requestParts.Length > 2)
            {
                action = requestParts[2];
            }

            if (requestParts.Length > 3)
            {
                options = requestParts[3];
            }


            string html = $"<h3>ESRI REST API {DateTime.Now}</h3>" + NL
                + requestURL + NL + "<br/>"
                + "request type: " + requestType + NL + "<br/>"
                + "controller: " + controller + NL + "<br/>"
                + "action: " + action + NL + "<br/>"
                + "options:" + options + NL;

            string response = "HTTP/1.1 200 OK" + NL
                + "Server: slav4o.com " + NL
                + "Content-Type: text/html; charset=utf-8" + NL
                + "Content-Length: " + html.Length + NL
                + NL
                + html + NL;


            return response;
        }
    }
}