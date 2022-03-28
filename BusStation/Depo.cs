using System;
using System.Collections.Generic;

namespace BusStation
{
    public class Depo
    {
        private Dictionary<string, HashSet<string>> Buses { get; set; }
        private Dictionary<string, HashSet<string>> Stops { get; set; }

        public Depo()
        {
            Buses = new Dictionary<string, HashSet<string>>();
            Stops = new Dictionary<string, HashSet<string>>();
        }

        public void AddBus(string route)
        {
            try
            {
                var routeParsed = route.Split(' ');
                var bus = routeParsed[1].Trim();
                Buses[bus] = new HashSet<string>();
                for (int i = 0; i < int.Parse(routeParsed[2]); i++)
                {
                    var station = routeParsed[i + 3].Trim();
                    if (!Stops.ContainsKey(station))
                    {
                        Stops[station] = new HashSet<string>();
                    }
                    Buses[bus].Add(station);
                    Stops[station].Add(bus);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetBusesForStop(string stationName)
        {
            string result = "";

            if (!Stops.ContainsKey(stationName))
            {
                return "No stop";
            }

            foreach (var bus in Stops[stationName])
            {
                result += $"{bus} ";
            }

            return result.Trim();
        }

        public List<string> GetStopsForBus(string busName)
        {
            List<string> result = new List<string>(); ;

            if (!Buses.ContainsKey(busName))
            {
                result.Add("No bus");
                return result;
            }

            foreach (var station in Buses[busName])
            {
                result.Add($"Stop {station}:");
                foreach (var bus in Stops[station])
                {
                    if (Stops[station].Count == 1)
                    {
                        result[^1] += " no interchange";
                        break;
                    }
                    if (bus == busName)
                        continue;
                    result[^1] += $" {bus}";
                }
            }

            return result;
        }

        public List<string> GetAllBuses()
        {
            List<string> result = new List<string>();
            if (Buses.Count == 0)
            {
                result.Add("No buses");
                return result;
            }

            foreach (var bus in Buses.Keys)
            {
                result.Add($"Bus {bus}:");
                foreach (var station in Buses[bus])
                {
                    result[^1] += $" {station}";
                }
            }
            result.Sort();

            return result;
        }
    }
}