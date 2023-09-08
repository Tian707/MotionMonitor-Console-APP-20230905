using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_0905_MotionDetector.BLL
{
    /// <summary>
    /// A container for content from table Distance
    /// Fill all props when fetching data fro DB
    /// for the presentation on webpage
    /// </summary>
    public class Record
    {  
        public int ID { get; set; }
        public float DistanceInCM { get; set; }
        public int LightCount { get; set; }
        public string ReceivingTime { get; set; }

    }
}
