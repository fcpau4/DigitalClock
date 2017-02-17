using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    [Serializable()]
    public class Alarm
    {
        public String currentTime { get; set; }
        public bool activate { get; set; }

        public Alarm(String currentTime)
        {
            this.currentTime = currentTime;
        }

        public Alarm(String currentTime, bool actv)
        {
            this.currentTime = currentTime;
            this.activate = actv;
        }
    }
}
