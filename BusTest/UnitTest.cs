using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusStations;
using System.Collections.Generic;

namespace BusTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAddingBusesIncreasesTheirCount()
        {
            Depo depo = new Depo();
            Assert.AreEqual(depo.GetAllBuses(), "No buses");
            Assert.AreEqual(depo.GetStopsForBus("Marushkino"), "No bus");

            depo.AddBus("NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo");
            /*Assert.AreEqual(depo.GetStopsForBus("32"), "Stop Tolstopaltsevo: no interchange\n" +  
                                                       "Stop Marushkino: no interchange\n" +
                                                       "Stop Vnukovo: no interchange");*/

            depo.AddBus("NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");
            Assert.AreEqual(depo.GetStopsForBus("32K"), new List<string> {"Stop Tolstopaltsevo: 32",
                                                                          "Stop Marushkino: 32",
                                                                          "Stop Vnukovo: 32",
                                                                          "Stop Peredelkino: no interchange",
                                                                          "Stop Solntsevo: no interchange",
                                                                          "Stop Skolkovo: no interchange" });

        }

        [TestMethod]
        public void TestAddingStationsIncreasesTheirCount()
        {
            Depo depo = new Depo();
            depo.AddBus("NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo");
            Assert.AreEqual(depo.GetBusesForStop("Marushkino"), "32");

            depo.AddBus("NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");
            Assert.AreEqual(depo.GetBusesForStop("Marushkino"), "32, 32K");

        }
    }
}
