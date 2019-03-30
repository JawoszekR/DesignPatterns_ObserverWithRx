namespace DesignPatterns_Observer
{
    public class Sensor
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public bool Rain { get; set; }

        public Sensor()
        {
            Temperature = 14.5;
            Pressure = 1100;
            Humidity = 0.3;
            Rain = false;
        }
    }
}