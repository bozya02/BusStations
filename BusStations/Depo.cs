﻿using System;
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
                return "No stop";
            }

            foreach (var bus in Stations[stationName])
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

            int iterator = 0;
            foreach (var station in Buses[busName])
            {
                result.Add($"Stop {station}: ");
                foreach (var bus in Stations[station])
                {
                    if (Stations[station].Count == 1)
                    {
                        result[iterator] += "no interchange";
                        break;
                    }
                    if (bus == busName)
                        continue;
                    result[iterator] += $"{bus} ";
                }
                result[iterator].Trim();
                iterator++;
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

            int iterator = 0;
            foreach (var bus in Buses.Keys)
            {
                result.Add($"Bus {bus}: ");
                foreach (var station in Buses[bus])
                {
                    result[iterator] += $"{station} ";
                }
                result[iterator].Trim();
                iterator++;
            }
            result.Sort();
            return result;
        }
    }
}
