using System;
using System.Collections.Generic;
using System.Linq;

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
            var depo = new Depo();

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
}
