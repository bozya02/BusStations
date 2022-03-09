using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusStations;

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
            /*Assert.AreEqual(depo.GetStopsForBus("32K"), "Stop Tolstopaltsevo: 32\n" +
                                                        "Stop Marushkino: 32\n" +
                                                        "Stop Vnukovo: 32\n" +
                                                        "Stop Peredelkino: no interchange\n" +
                                                        "Stop Solntsevo: no interchange\n" +
                                                        "Stop Skolkovo: no interchange\n");*/

        }
    }
}
