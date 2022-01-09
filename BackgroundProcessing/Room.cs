using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackgroundProcessing
{
    public class Room
    {
        public int id { get; set; }
        public string room { get; set; }
        public string conditioner { get; set; }
        public int[] repeater { get; set; }

        public override string ToString()
        {
            string repeaters = "";

            foreach (var item in repeater)
            {
                repeaters += item.ToString();
                repeaters += ",";
            }

            return id.ToString() + "\r\n" + room + "\r\n " + conditioner + "\r\n" + "repeaters: " + repeaters;
        }
    }
}
