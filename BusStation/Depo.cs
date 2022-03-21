using System;
using System.Collections.Generic;

namespace BusStation
{
    public class Depo
    {
        private Dictionary<string, HashSet<string>> _buses { get; set; }
        private Dictionary<string, HashSet<string>> _stations { get; set; }

        public Depo()
        {
            _buses = new Dictionary<string, HashSet<string>>();
            _stations = new Dictionary<string, HashSet<string>>();
        }

        public void AddBus(string route)
        {
            //NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo
            try
            {
                var routeParsed = route.Split(' ');
                var bus = routeParsed[1].Trim();
                _buses[bus] = new HashSet<string>();
                for (int i = 0; i < int.Parse(routeParsed[2]); i++)
                {
                    var station = routeParsed[i + 3].Trim();
                    if (!_stations.ContainsKey(station))
                    {
                        _stations[station] = new HashSet<string>();
                    }
                    _buses[bus].Add(station);
                    _stations[station].Add(bus);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string GetBusesForStop(string stationName)
        {
            string result = "";

            if (!_stations.ContainsKey(stationName))
            {
                return "No stop";
            }

            foreach (var bus in _stations[stationName])
            {
                result += $"{bus} ";
            }

            return result.Trim();
        }

        public List<string> GetStopsForBus(string busName)
        {
            List<string> result = new List<string>(); ;

            if (!_buses.ContainsKey(busName))
            {
                result.Add("No bus");
                return result;
            }

            int iterator = 0;
            foreach (var station in _buses[busName])
            {
                result.Add($"Stop {station}: ");
                foreach (var bus in _stations[station])
                {
                    if (_stations[station].Count == 1)
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
            if (_buses.Count == 0)
            {
                result.Add("No buses");
                return result;
            }

            int iterator = 0;
            foreach (var bus in _buses.Keys)
            {
                result.Add($"Bus {bus}: ");
                foreach (var station in _buses[bus])
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