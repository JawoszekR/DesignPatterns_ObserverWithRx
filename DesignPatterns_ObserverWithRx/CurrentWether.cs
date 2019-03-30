using DesignPatterns_ObserverWithRx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class CurrentWether : IObserver<WetherStationDTO>
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public bool Rain { get; set; }
        

        public CurrentWether()
        {
        }

        public void DisplayWeather()
        {
            Console.WriteLine("Temperature: " + Temperature);
            Console.WriteLine("Pressure: " + Pressure);
            Console.WriteLine("Humidity: " + Humidity);
            Console.WriteLine("Rain: " + Rain);
        }

        public void OnNext(WetherStationDTO value)
        {
            UpdateTemperatureIfValuePropNotNull(value);
            UpdatePressureIfValuePropNotNull(value);
            UpdateHumidityIfValuePropNotNull(value);
            UpdateRainIfValueNotPropNull(value);
        }

        private void UpdateTemperatureIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Temperature != null)
                Temperature = (double)value.Temperature;
        }
        private void UpdatePressureIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Pressure != null)
                Pressure = (double)value.Pressure;
        }
        private void UpdateHumidityIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Humidity != null)
                Humidity = (double)value.Humidity;
        }
        private void UpdateRainIfValueNotPropNull(WetherStationDTO value)
        {
            if (value.Rain != null)
                Rain = (bool)value.Rain;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
