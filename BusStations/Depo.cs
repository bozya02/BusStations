using System;
using System.Collections.Generic;
using System.Linq;

namespace BusStations
{
    public class Depo
    {
        public Dictionary<string, HashSet<string>> Buses { get; set; }
        public Dictionary<string, HashSet<string>> Stations { get; set; }

        public Depo()
        {
            Buses = new Dictionary<string, HashSet<string>>();
            Stations = new Dictionary<string, HashSet<string>>();
        }
        
        public void AddBus(string route)
        {
            //NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo
            var routeParsed = route.Split(' ');
            var bus = routeParsed[1].Trim();
            Buses[bus] = new HashSet<string>();
            for (int i = 0; i < int.Parse(routeParsed[2]); i++ )
            {
                var station = routeParsed[i + 3].Trim();
                if (!Stations.ContainsKey(station))
                {
                    Stations[station] = new HashSet<string>();
                }
                Buses[bus].Add(station);
                Stations[station].Add(bus);
            }
        }

        public string GetBusesForStop(string stationName)
        {
            string result = "";

            if (!Stations.ContainsKey(stationName))
            {
                return result + "No stop";
            }

            foreach (var bus in Stations[stationName])
            {
                result += $"{bus} ";
            }

            return result.Trim();
        }

        public string GetStopsForBus(string busName)
        {
            string result = "";

            if (!Buses.ContainsKey(busName))
            {
                return result + "No bus";
            }

            foreach (var station in Buses[busName])
            {
                result += $"Stop {station}: ";
                foreach (var bus in Stations[station])
                {
                    if (Stations[station].Count == 1)
                    {
                        result += "no interchange";
                        break;
                    }
                    if (bus == busName)
                        continue;
                    result += $"{bus} ";
                }
                result.Trim();
                result += Environment.NewLine;
            }

            return result.Trim();
        }
    }
}
