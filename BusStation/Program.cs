using System;

namespace BusStation
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
                        foreach (var stop in depo.GetStopsForBus(command[1]))
                        {
                            Console.WriteLine(stop);
                        }
                        Console.WriteLine();
                        break;

                    case "ALL_BUSES":
                        foreach (var bus in depo.GetAllBuses())
                        {
                            Console.WriteLine(bus);
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}