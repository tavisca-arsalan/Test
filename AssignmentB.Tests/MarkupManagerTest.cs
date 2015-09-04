using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace AssignmentB.Tests
{
    [TestClass]
    public class MarkupManagerTest
    {
        [TestMethod]
        public void TestCalculateMarkupForIrrelevantDiscountedFare()
        {
            System.Collections.Generic.List<Itinerary> disountList = new System.Collections.Generic.List<Itinerary>();

            Itinerary published = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 1,

                TotalLayoverTime = new TimeSpan(1, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 100,

                MarkupInUSD = 0

            };

            Itinerary discounted1 = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 0,

                TotalLayoverTime = new TimeSpan(0, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 60,

                MarkupInUSD = 0

            };

            disountList.Add(discounted1);
            Itinerary discounted2 = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 2,

                TotalLayoverTime = new TimeSpan(1, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 110,

                MarkupInUSD = 0

            };

            disountList.Add(discounted2);

            disountList = new MarkupManager().CalculateMarkup(published, disountList);

            Assert.AreEqual(1, disountList.Count);
        }

        [TestMethod]
        public void TestCalculateMarkupForMinimumFareDifference()
        {
            System.Collections.Generic.List<Itinerary> disountList = new System.Collections.Generic.List<Itinerary>();

            Itinerary published = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 1,

                TotalLayoverTime = new TimeSpan(4, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 100,

                MarkupInUSD = 0

            };

            Itinerary discounted1 = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 2,

                TotalLayoverTime = new TimeSpan(0, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 60,

                MarkupInUSD = 0

            };

            disountList.Add(discounted1);
            Itinerary discounted2 = new Itinerary()
            {
                OriginAirportCode = "001",

                DestinationAirportCode = "005",

                FlightTime = new TimeSpan(4, 0, 0),

                NumberOfStops = 3,

                TotalLayoverTime = new TimeSpan(0, 0, 0),

                Airline = "Indigo",

                UtcDepartureTime = DateTime.UtcNow,

                UtcArrivalTime = DateTime.UtcNow,

                BaseFareInUSD = 60,

                MarkupInUSD = 0

            };

            disountList.Add(discounted2);

            disountList = new MarkupManager().CalculateMarkup(published, disountList);

            Assert.AreEqual(15, disountList[0].TotalFareInUSD - disountList[1].TotalFareInUSD);
        }
    }
}
