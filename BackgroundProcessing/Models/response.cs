using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundProcessing
{
    public class response
    {
        public string objectIdFieldName { get; set; }
        public dynamic uniqueIdField { get; set; }
        public string globalIdFieldName { get; set; }
        public dynamic geometryType { get; set; }
        public dynamic spatialReference { get; set; }
        public dynamic fields { get; set; }
        public bool exceededTransferLimit { get; set; }
        public List<state> features { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("objectIdFieldName -  " + objectIdFieldName);
            //features.ForEach(f => result.AppendLine(f.ToString()));
            int cnt = 1;
            foreach (var feature in features)
            {
                result.AppendLine(cnt.ToString() + ". " + feature.ToString());
                cnt++;
            }
            return result.ToString();
        }
    }
}

