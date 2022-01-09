using System;
using System.Collections.Generic;
using System.Text;
using static WEBService.Controller;

namespace WEBService.Views
{
    public class IndexView
    {
        public override string ToString()
        {
            //string resultHtml = $"<h3>ESRI REST API {DateTime.Now}</h3>" + NL
            //        + requestURLString + NL + "<br/>"
            //        + "request type: " + requestType + NL + "<br/>"
            //        + "controller: " + controller + NL + "<br/>"
            //        + "action: " + action + NL + "<br/>"
            //        + "options:" + options + NL;

            string resultHtml = $"<h3>ESRI REST API</h3>" + NL
                + "<br/> usage: stats/state=StateName&format=FormatType" + NL
                + "<br/> where: StateName is name of state" + NL
                + "  FormatType is <b>json</b> or <b>html</b>";
            return resultHtml;
        }
    }
}
