using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class weatherStation : observable
    {
        public enum eventTypes
        {
            All,
            Min,
            Max
        }

        public double temperature;
        public double humidity;
        public double pressure;

        private List<weatherStationObserver> observerList = new List<weatherStationObserver>();

        private List<ChangeTracker> history = new List<ChangeTracker>();

        private double maxHumidity = 0.0;
        private double minHumidity = 0.0;
        private double maxPressure = 0.0;
        private double minPressure = 0.0;
        private double maxTemperature = 0.0;
        private double minTemperature = 0.0;

        //average counter
        
        public weatherStation(double atemp, double ahumidity, double apressure)
        {
            this.temperature = atemp;
            this.humidity = ahumidity;
            this.pressure = apressure;
            this.maxTemperature = atemp;
            this.minTemperature = atemp;
            this.maxPressure = apressure;
            this.minPressure = apressure;
            this.maxHumidity = ahumidity;
            this.minHumidity = ahumidity;
            this.history.Add(new ChangeTracker(ChangeTracker.Types.Humidity, ahumidity));
            this.history.Add(new ChangeTracker(ChangeTracker.Types.Temperature, atemp));
            this.history.Add(new ChangeTracker(ChangeTracker.Types.Pressure, apressure));
        }

        public double Temperature
        {
            get { return temperature; }
            set
            {
                if(value > this.maxTemperature) { this.maxTemperature =value; this.notify(weatherStation.eventTypes.Max); }
                if(value< this.minTemperature) { this.minTemperature =value; this.notify(weatherStation.eventTypes.Min); }
                this.temperature = value;
                this.notify();
                this.history.Add(new ChangeTracker(ChangeTracker.Types.Temperature, value));
            }
        }

        public double Humidity
        {
            get { return humidity; }
            set
            {
                this.humidity = value;
                this.notify();
                this.history.Add(new ChangeTracker(ChangeTracker.Types.Humidity, value));
                if (value > this.maxHumidity) { this.maxHumidity = value; this.notify(weatherStation.eventTypes.Max); }
                if (value < this.minHumidity) { this.minHumidity = value; this.notify(weatherStation.eventTypes.Min); }
            }
        }

        public double Pressure
        {
            get { return pressure; }
            set
            {
                this.history.Add(new ChangeTracker(ChangeTracker.Types.Pressure, value));
                this.pressure = value;
                this.notify();
                if (value > this.maxPressure) { this.maxPressure= value; this.notify(weatherStation.eventTypes.Max); }
                if (value < this.minPressure) { this.minPressure = value; this.notify(weatherStation.eventTypes.Min); }
            }
        }

        public void notify(weatherStation.eventTypes event_type = eventTypes.All)
        {
            foreach (weatherStationObserver weatherStationObserver in this.observerList)
            {
                if(weatherStationObserver.eventName == event_type)
                {
                    weatherStationObserver.user.update(this, weatherStationObserver);
                }
            }
        }

        public void subscribe(user observer, weatherStation.eventTypes eventType)
        {
            this.observerList.Add(new weatherStationObserver(observer,eventType));
        }

        public void unsubscribe(user observer, weatherStation.eventTypes eventType)
        {
            weatherStationObserver wso_to_remove = null;
            foreach(weatherStationObserver wso in this.observerList)
            {
                if(wso.eventName == eventType && wso.user == observer) {
                    wso_to_remove = wso;
                    break;
                }
            }
            this.observerList.Remove(wso_to_remove);
        }

        private string getAvgerage()
        {
            double temperature_average = 0.0;
            double humidity_average = 0.0;
            double pressure_average = 0.0;
            int t_count = 1;
            int h_count = 1;
            int p_count = 1;
            
            foreach (ChangeTracker history_entry in this.history)
            {
                if (history_entry.type == ChangeTracker.Types.Temperature.ToString())
                {
                    temperature_average = temperature_average+history_entry.value;
                    t_count++;
                }

                if (history_entry.type == ChangeTracker.Types.Humidity.ToString())
                {
                    humidity_average = humidity_average + history_entry.value;
                    h_count++;
                }


                if (history_entry.type == ChangeTracker.Types.Pressure.ToString())
                {
                    pressure_average = pressure_average + history_entry.value;
                    p_count++;
                }
            }

            return "Average temperature is "+(temperature_average/t_count).ToString()+"\n"+
                "Average humidity is "+(humidity_average/h_count).ToString() + "\n" +
                "Average pressure is " +(pressure_average/p_count).ToString() + "\n";

        }

        public string toString()
        {

            return 
                "Temperate is " + this.temperature.ToString() + "\n" +
                "Maximum temperate is " + this.maxTemperature.ToString() + "\n" +
                "Minimum temperate is " + this.minTemperature.ToString() + "\n \n" +
                "Humidity is " + this.humidity.ToString() + "\n" +
                "Maximum Humidity is " + this.maxHumidity.ToString() + "\n" +
                "Minimum Humidity is " + this.minHumidity.ToString() + "\n \n" +
                "Pressure is " + this.pressure.ToString() + "\n" +
                "Maximum Pressure is " + this.maxPressure.ToString() + "\n" +
                "Minimum Pressure is " + this.minPressure.ToString() + "\n \n"+this.getAvgerage();
        }
    }
}
