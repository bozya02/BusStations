using System;
using System.Collections.Generic;

namespace BusStations
{
    public class Station
    {
        public string Name { get; set; }
        
        /*
        public List<Bus> Buses { get; set; }

        public Station()
        {
            Buses = new List<Bus>();
        }

        */
        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            return this.Name == (obj as Station).Name;
        }
    }
}
