using System;
using System.Timers;

namespace ColdFrame.MeterReadings
{
    public class Readings
    {
        public double Ph { get; set; }
        public int Moisture { get; set; }
        
        
        public double GeneratePh()
        {
            Ph = new Random().NextDouble() * (8 - 5);
            return Math.Round(Ph, 1);
        }

        public int GenerateMoisture()
        {
            return Moisture = new Random().Next(1, 100);
        }

        public Timer ReadingsTimer()
        {
            return new Timer(86400000D);
        }
        
    }
    
    
}