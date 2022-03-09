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
                        Console.WriteLine(depo.GetBusesForStop("Vnukovo"));
                            break;

                    case "STOPS_FOR_BUS":
                        //Console.WriteLine(synonyms.AreSynonyms(command[1], command[2]) ? "YES" : "NO");
                        break;

                    case "ALL_BUSES":
                        
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
