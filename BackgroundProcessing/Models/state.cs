using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundProcessing
{
    public class state
    {
        public attributes attributes { get; set; }

        public override string ToString()
        {
            //var result = "state - " + this.attributes.STATE_NAME + ", population - " + this.attributes.POPULATION.ToString();
            var result = this.attributes.POPULATION + " " + this.attributes.STATE_NAME;
            return result;
        }
    }
}
