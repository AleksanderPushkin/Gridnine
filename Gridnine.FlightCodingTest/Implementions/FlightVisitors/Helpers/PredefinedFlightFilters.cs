using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors.Helpers
{
    public static class PredefinedFlightFilters
    {
        public static Func<Flight, bool> DepartureBeforeDate(DateTime dateTime) { return t => t.Segments.OrderBy(t => t.DepartureDate).First().DepartureDate < dateTime; }

        public static Func<Flight, bool> DepartureAfterArrival =  t => t.Segments.Any(t => t.DepartureDate > t.ArrivalDate);
    }
}
