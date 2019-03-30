using DesignPatterns_Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPatterns_ObserverWithRx
{
    class Program
    {
        static void Main(string[] args)
        {
            Sensor sensor = new Sensor();
            WetherStation ws = new WetherStation();
            CurrentWether cw = new CurrentWether();
            AverageWether aw1 = new AverageWether();
            AverageWether aw2 = new AverageWether();
            IDisposable sub1;
            IDisposable sub2;

            Task.Factory.StartNew(() => ws.ObserveSensor(sensor));
            Task.Factory.StartNew(() => { while (true) { Thread.Sleep(5000); Console.WriteLine("Current Wether: "); cw.DisplayWeather(); Console.WriteLine(); } });
            Thread.Sleep(500);
            Task.Factory.StartNew(() => { while (true) { Thread.Sleep(5000); Console.WriteLine("Average Wether1: "); aw1.DisplayWeather(); Console.WriteLine(); } });
            Thread.Sleep(500);
            Task.Factory.StartNew(() => { while (true) { Thread.Sleep(5000); Console.WriteLine("Average Wether2: "); aw2.DisplayWeather(); Console.WriteLine(); } });

            sub1 = ws.Subscribe(cw);
            sub2 = ws.Subscribe(aw1);

            sensor.Temperature = 18;
            Thread.Sleep(6000);
            sensor.Pressure = 1150;
            Thread.Sleep(5000);
            sensor.Rain = true;
            sensor.Humidity = 0.7;
            Thread.Sleep(5000);
            sensor.Temperature = 9;
            sub1.Dispose();
            sub1 = ws.Subscribe(aw2);
            sensor.Rain = false;
            Thread.Sleep(5000);
            sensor.Humidity = 0.4;
            Thread.Sleep(5000);
            sensor.Temperature = -1;

            Console.ReadKey();

        }
    }
}
