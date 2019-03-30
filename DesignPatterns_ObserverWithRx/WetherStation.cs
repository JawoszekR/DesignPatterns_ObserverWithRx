using DesignPatterns_ObserverWithRx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class WetherStation : IObservable<WetherStationDTO>
    {
        private List<double> temperature;
        private List<double> pressure;
        private List<double> humidity;
        private List<bool> rain;

        private List<Subscribtion> subscriptions;

        public WetherStation()
        {
            subscriptions = new List<Subscribtion>();
            temperature = new List<double>();
            pressure = new List<double>();
            humidity = new List<double>();
            rain = new List<bool>();
        }

        public IDisposable Subscribe(IObserver<WetherStationDTO> observer)
        {
            Subscribtion sub = new Subscribtion(this, observer);
            subscriptions.Add(sub);
            SendAllDataToSubscriber(sub);
            return sub;
        }

        private void SendAllDataToSubscriber(Subscribtion sub)
        {
            foreach (var temp in temperature)
            {
                sub.Obserwer.OnNext(new WetherStationDTO()
                {
                    Humidity = null,
                    Pressure = null,
                    Temperature = temp,
                    Rain = null
                });
            }
            foreach (var pres in pressure)
            {
                sub.Obserwer.OnNext(new WetherStationDTO()
                {
                    Humidity = null,
                    Pressure = pres,
                    Temperature = null,
                    Rain = null
                });
            }
            foreach (var hum in humidity)
            {
                sub.Obserwer.OnNext(new WetherStationDTO()
                {
                    Humidity = hum,
                    Pressure = null,
                    Temperature = null,
                    Rain = null
                });
            }
            foreach (var ri in rain)
            {
                sub.Obserwer.OnNext(new WetherStationDTO()
                {
                    Humidity = null,
                    Pressure = null,
                    Temperature = null,
                    Rain = ri
                });
            }
        }

        public void RemoveSubscription(Subscribtion sub)
        {
            subscriptions.Remove(sub);
        }

        private void UpdateSubscribers(WetherStationDTO wetherStationDTO)
        {
            foreach (var subscriber in subscriptions)
            {
                subscriber.Obserwer.OnNext(wetherStationDTO);
            }
        }

        public void AddTemperature(double temperature)
        {
            this.temperature.Add(temperature);
            UpdateSubscribers(new WetherStationDTO()
            {
                Humidity = null,
                Pressure = null,
                Rain = null,
                Temperature = temperature
            });
        }

        public void AddPressure(double pressure)
        {
            this.pressure.Add(pressure);
            UpdateSubscribers(new WetherStationDTO()
            {
                Humidity = null,
                Pressure = pressure,
                Rain = null,
                Temperature = null
            });
        }

        public void AddHumidity(double humidity)
        {
            this.humidity.Add(humidity);
            UpdateSubscribers(new WetherStationDTO()
            {
                Humidity = humidity,
                Pressure = null,
                Rain = null,
                Temperature = null
            });
        }

        public void AddRain(bool rain)
        {
            this.rain.Add(rain);
            UpdateSubscribers(new WetherStationDTO()
            {
                Humidity = null,
                Pressure = null,
                Rain = rain,
                Temperature = null
            });
        }

        public void ObserveSensor(Sensor sensor)
        {
            while (true)
            {
                if (temperature.LastOrDefault() != sensor.Temperature)
                    AddTemperature(sensor.Temperature);
                if (humidity.LastOrDefault() != sensor.Humidity)
                    AddHumidity(sensor.Humidity);
                if (pressure.LastOrDefault() != sensor.Pressure)
                    AddPressure(sensor.Pressure);
                if (rain.LastOrDefault() != sensor.Rain)
                    AddRain(sensor.Rain);
            }
        }
    }
}
