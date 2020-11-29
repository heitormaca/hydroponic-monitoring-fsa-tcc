using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.ViewModel
{
    public class GraphicViewModel
    {
        public class ValueResult {
            public double Value { get; set; }
            public double MaxValue { get; set; }
            public double MinValue { get; set; }
        }

        public ValueResult SensorTempBanc { get; set; }        
        public ValueResult SensorTempSol { get; set; }        
        public ValueResult SensorPh { get; set; }        
        public ValueResult SensorEc { get; set; }        

        public DateTime Date { get; set; }
    }
}
