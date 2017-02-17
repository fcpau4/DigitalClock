using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{

    [Serializable()]
    class TimeDifference
    {

        public String countryName { get; set; }
        public int timeDifference { get; set; }

        public TimeDifference(String cn, int td)
        {
            countryName = cn;
            timeDifference = td;
        }
    }
}
