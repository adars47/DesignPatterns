using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class user : observer
    {
        public string name = "";
        public user(string aname) {
            this.name = aname;
        }
       public void update(weatherStation obj,weatherStationObserver wso)
        {
            Console.WriteLine("Updating user " + wso.user.name+" for " + wso.eventName.ToString() + "\n");
            Console.WriteLine(obj.toString());
        }
    }
}
