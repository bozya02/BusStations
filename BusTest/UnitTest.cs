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

            List<string> list = new List<string>();
            list.Add("Stop Tolstopaltsevo: 32 ");
            list.Add("Stop Marushkino: 32 ");
            list.Add("Stop Vnukovo: 32 ");
            list.Add("Stop Peredelkino: no interchange");
            list.Add("Stop Solntsevo: no interchange");
            list.Add("Stop Skolkovo: no interchange");

            depo.AddBus("NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo");
            depo.AddBus("NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");

            CollectionAssert.AreEquivalent(depo.GetStopsForBus("32K"), list);

        }

        [TestMethod]
        public void TestAddingStationsIncreasesTheirCount()
        {
            Depo depo = new Depo();
            depo.AddBus("NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo");
            Assert.AreEqual(depo.GetBusesForStop("Marushkino"), "32");

            depo.AddBus("NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");
            Assert.AreEqual(depo.GetBusesForStop("Marushkino"), "32 32K");

        }

        [TestMethod]
        public void TestCallingAllBusesMethod()
        {
            Depo depo = new Depo();


            List<string> list = new List<string>();
            list.Add("No buses");

            CollectionAssert.AreEquivalent(depo.GetAllBuses(), list);
        }
    }
}
