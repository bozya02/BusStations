using System;
using System.Collections.Generic;

namespace BusStations
{
    public class Bus
    {
        public string Name { get; set; }
        /*public List<Station> Stations { get; set; }

        public Bus()
        {
            Stations = new List<Bus>();
        }
        */
        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            return this.Name == (obj as Bus).Name;
        }

    }
}
