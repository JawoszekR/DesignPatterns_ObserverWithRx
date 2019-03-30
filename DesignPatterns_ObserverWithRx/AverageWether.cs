using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class AverageWether : IObserver<WetherStationDTO>
    {
        public List<double> TemperatureList { get; set; }
        public List<double> PressureList { get; set; }
        public List<double> HumidityList { get; set; }


        public AverageWether()
        {
            TemperatureList = new List<double>();
            PressureList = new List<double>();
            HumidityList = new List<double>();
        }

        public void DisplayWeather()
        {
            if (TemperatureList.Any())
                Console.WriteLine("Average temperature: " + TemperatureList.Average());
            if (PressureList.Any())
                Console.WriteLine("Average pressure: " + PressureList.Average());
            if (HumidityList.Any())
                Console.WriteLine("Average humidity: " + HumidityList.Average());
        }

        public void OnNext(WetherStationDTO value)
        {
            UpdateTemperatureIfValuePropNotNull(value);
            UpdatePressureIfValuePropNotNull(value);
            UpdateHumidityIfValuePropNotNull(value);
        }

        private void UpdateTemperatureIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Temperature != null)
                TemperatureList.Add((double)value.Temperature);
        }
        private void UpdatePressureIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Pressure != null)
                PressureList.Add((double)value.Pressure);
        }
        private void UpdateHumidityIfValuePropNotNull(WetherStationDTO value)
        {
            if (value.Humidity != null)
                HumidityList.Add((double)value.Humidity);
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
