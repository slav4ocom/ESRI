using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundProcessing
{
    public class attributes
    {
        public int POPULATION { get; set; }
        public string STATE_NAME { get; set; }

        //public dynamic POPULATION { get; set; }
        //public dynamic STATE_NAME { get; set; }

        public override string ToString()
        {
            //var result = "Щат: " + this.STATE_NAME.ToString() + "Популация: " + this.POPULATION.ToString();
            var result = this.STATE_NAME;
            //var result = "baldsasdak";
            return result;
        }
    }
}
