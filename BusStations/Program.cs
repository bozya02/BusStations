using System;
using System.Collections.Generic;
using System.Linq;

namespace BusStations
{
    class Program
    {
        public static void Main(string[] args)
        {
            var depo = new Depo();

            int querryCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < querryCount; i++)
            {
                string line = Console.ReadLine();
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "NEW_BUS":
                        depo.AddBus(line);
                        break;

                    case "BUSES_FOR_STOP":
                        Console.WriteLine(depo.GetBusesForStop(command[1]));
                            break;

                    case "STOPS_FOR_BUS":
                        Console.WriteLine(depo.GetStopsForBus(command[1]));
                        break;

                    case "ALL_BUSES":
                        Console.WriteLine(depo.GetAllBuses());
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
