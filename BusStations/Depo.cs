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
                    result += $"{bus} ";
                }
                result.Trim();
                result += Environment.NewLine;
            }

            return result.Trim();
        }
    }

    public class City
    {
        public Dictionary<string, HashSet<string>> Transport { get; set; }
        public Dictionary<string, HashSet<string>> Stations { get; set; }

        public City()
        {
            Transport = new Dictionary<string, HashSet<string>>();
            Stations = new Dictionary<string, HashSet<string>>();
        }

        public void AddTransport(string route)
        {
            var transport = route.Split(':')[0];
            if (!Transport.ContainsKey(transport))
            {
                Transport[transport] = new HashSet<string>();
            }
            foreach (var station in route.Split(':')[1].Split(','))
            {
                var tempStation = station.Trim();
                Transport[transport].Add(tempStation);
                if (!Stations.ContainsKey(tempStation))
                {
                    Stations[tempStation] = new HashSet<string>();
                }
                Stations[tempStation].Add(transport);
            }
        }

        public void AddStation(string route)
        {
            var station = route.Split(':')[0];
            if (!Stations.ContainsKey(station))
            {
                Stations[station] = new HashSet<string>();
            }
            foreach (var bus in route.Split(':')[1].Split(','))
            {
                var tempTransport = bus.Trim();
                Stations[station].Add(tempTransport);
                if (!Transport.ContainsKey(tempTransport))
                {
                    Transport[tempTransport] = new HashSet<string>();
                }
                Transport[tempTransport].Add(station);
            }
        }

        public string[] GetStations(string bus)
        {
            if (Transport.ContainsKey(bus))
            {
                foreach (var station in Transport[bus])
                {
                    Console.WriteLine(station);
                }
            }
            return Transport[bus].ToArray();
        }
        public void GetBuses(string station)
        {
            if (Stations.ContainsKey(station))
            {
                foreach (var bus in Stations[station])
                {
                    Console.WriteLine(bus);
                }
            }
        }
        public string[] GetAllBuses()
        {
            return Transport.Keys.ToArray();
        }
    }
}
