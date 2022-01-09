using System;
using System.Collections.Generic;
using System.Text;

namespace WEBService.Models
{
    public class StateResult
    {
        public string error { get; set; }
        public string STATE_NAME { get; set; }
        public long POPULATION { get; set; }
        public string lastUpdated { get; set; }

    }
}
