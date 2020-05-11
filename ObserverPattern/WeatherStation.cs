using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{

    public class WeatherStation : IObservable
    {
        public List<IObserver> clientsList;
        private Weather state;
        private string degrees;
        private string rain;
        private string wind;
        public void Add(IObserver o)
        {
            clientsList.Add(o);
        }

        public WeatherStation()
        {
            clientsList = new List<IObserver>();
        }

        public Weather State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Notify();
            }
        }
        public String Degrees
        {
            get
            {
                return degrees;
            }
            set
            {
                degrees = value;
                Notify();
            }
        }
        public String Rain
        {
            get
            {
                return rain;
            }
            set
            {
                rain = value;
                Notify();
            }
        }
        public String Wind
        {
            get
            {
                return wind;
            }
            set
            {
                wind = value;
                Notify();
            }
        }
        public void Notify()
        {
            foreach (var client in clientsList)
            {
                client.Update();
            }
        }

        public void Remove(IObserver o)
        {
            clientsList.Remove(o);
        }

    }
}
