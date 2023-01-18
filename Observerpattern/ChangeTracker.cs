using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    //this class will represent a single change in the data for a specific weather station and a specific sensor value
    public class ChangeTracker
    {
        //our system accounts for three sensor types
        public enum Types
        {
            Temperature,
            Humidity,
            Pressure
        }

        //type will be the type of sensor data being collected
        public string type = "";
        //value is the latest value set by that sensor
        public double value = 0.0;

        public ChangeTracker(Types a, double value)
        {
            this.type = a.ToString();
            this.value = value;
        }
    }
}
