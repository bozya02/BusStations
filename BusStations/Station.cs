using System;
using System.Collections.Generic;

namespace BusStations
{
    public class Station
    {
        public string Name { get; set; }
        public List<Bus> Buses { get; set; }

        public Station()
        {
            Buses = new List<Bus>();
        }

        public override string ToString()
        {
            string result = $"Stop {Name}:";
            foreach (var bus in Buses)
            {
                result += $" {bus.Name}";
            }
            return result;
        }
    }
}
