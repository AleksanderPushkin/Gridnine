using Gridnine.FlightCodingTest.Implementions.FlightVisitors.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gridnine.FlightCodingTest.Test
{
    public class UnitTest1
    {
        [Fact]
       
        public void IsDepartureAfterArrivalCorrect()
        {
            var flight = new Flight { Segments = new List<Segment> { new Segment { ArrivalDate = DateTime.Now.AddDays(-2), DepartureDate = DateTime.Now } } };
            bool result = PredefinedFlightFilters.DepartureAfterArrival(flight);
            Assert.Equal(result, true);
        }
    }
}
