using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface observable
    {
        public void subscribe(user ob, weatherStation.eventTypes eventType);
        public void unsubscribe(user ob, weatherStation.eventTypes eventType);
        public void notify(weatherStation.eventTypes event_type);
        public String toString();
    }
}
