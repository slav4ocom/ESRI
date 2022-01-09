﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEBService.Controllers;
using WEBService.Views;

namespace WEBService
{
    public static class Controller
    {
        public const string NL = "\r\n";
        public static string requestURLString = "";
        public static string[] requestParts = new string[4];
        public static string requestType = "";
        public static string controller = "";
        public static string action = "";
        public static string options = "";

        public static string format = "";
        //static string state = "";
        public static string html = "";
        public static string MainController(string requestURL)
        {
            requestURLString = requestURL;
            requestParts = requestURLString.Split("/");
            requestType = requestParts[0];

            if (requestParts.Length > 1)
            {
                controller = requestParts[1].Trim();
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


            if (controller == "" || controller == "index.html")
            {
                new IndexController();
            }
            else if (controller == "stats")
            {
                new StatisticsController();
            }
            else
            {
                //html = "<h2> 404 not found</h2>";
                html = "";
            }
            //var html = Views.Index;

            string response = "HTTP/1.1 200 OK" + NL
                + "Server: slav4o.com " + NL
                + "Content-Type: " + GetContentType() + NL
                //+ "Content-Type: text/html; charset=utf-8" + NL
                + "Content-Length: " + html.Length + NL
                + NL
                + html + NL;


            return response;
        }

        private static string GetContentType()
        {
            var result = "text/html; charset=utf-8";
            if (format == "json")
            {
                result = "text/json; charset=utf-8";
            }

            return result;
        }
    }
}