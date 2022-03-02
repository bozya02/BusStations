using System;
using System.Collections.Generic;

namespace BusStations
{
    class Program
    {
        public static void Main(string[] args)
        {
            string route = "63: Советская площадь, Полет, Космонавтов";
            string station = "КАИ: 63, 1, 4";
            var Kazan = new City();
            Kazan.AddTransport(route);
            Kazan.AddStation(station);
            Kazan.GetStations("63");
            Kazan.GetBuses("Полет");
            Kazan.GetStations("4");
            int querryCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < querryCount; i++)
            {
                string line = Console.ReadLine();
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "NEW_BUS":
                        //synonyms.Add(command[1], command[2]);
                        break;

                    case "BUSES_FOR_STOP":
                        //Console.WriteLine(synonyms.GetSynonymCount(command[1]));
                        break;

                    case "STOPS_FOR_BUS":
                        //Console.WriteLine(synonyms.AreSynonyms(command[1], command[2]) ? "YES" : "NO");
                        break;

                    case "ALL_BUSES":
                        foreach (string bus in Kazan.GetAllBuses())
                            Console.WriteLine(bus);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }

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
