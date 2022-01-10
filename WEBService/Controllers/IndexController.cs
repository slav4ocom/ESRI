using System;
using System.Collections.Generic;
using System.Text;
using static WEBService.Controller;

namespace WEBService.Controllers
{
    class IndexController
    {
        public IndexController()
        {
            content = $"<h3>ESRI REST API</h3>" + NL
              + "<br/> usage: stats/state=StateName&format=FormatType" + NL
              + "<br/> where: StateName is name of state" + NL
              + "  FormatType is <b>json</b> or <b>html</b>";
        }
    }
}
