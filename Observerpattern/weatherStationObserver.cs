using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class weatherStationObserver
    {
        public user user;
        public weatherStation.eventTypes eventName;

        public weatherStationObserver(user us, weatherStation.eventTypes eventName)
        {
            this.user = us;
            this.eventName = eventName;
        }
    }
}
