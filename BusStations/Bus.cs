using System;
using System.Collections.Generic;

namespace BusStations
{
    public class Bus
    {
        public string Name { get; set; }
        List<Station> Stations { get; set; }

        public override string ToString()
        {
            string result = $"Bus {Name}:";
            foreach (var station in Stations)
            {
                result += $" {station.Name}";
            }
            return result;
        }
    }
}
