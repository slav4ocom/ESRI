using System;
using System.Collections.Generic;
using System.Text;
using WEBService.Views;
using static WEBService.Controller;

namespace WEBService.Controllers
{
    class IndexController
    {
        public IndexController()
        {
            html = new IndexView().ToString();
        }
    }
}
