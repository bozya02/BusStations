using System;
using System.Collections.Generic;
using System.Linq;

namespace BusStations
{
    public class Depo
    {
        public List<Bus> Buses { get; set; }
        public List<Station> Stations { get; set; }

        public Depo()
        {
            Buses = new List<Bus>();
            Stations = new List<Station>();
        }
        /*
        public void AddTransport(string route)
        {
            var transport = route.Split(' ')[0];
            var bus = new Bus() { Name = transport };
            for (int i = 0; i<int.Parse(route.Split(' ')[1]);i++)
            {
                bus.Stations.Add(new Station
                {
                    Name = route.Split(' ')[2 + i],
                    Buses.Add
                });
            }

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
        */
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
