using Gridnine.FlightCodingTest.Implementions.FlightVisitors.Helpers;
using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Linq;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors
{
    public static class GenetricFilterVisitorFactory
    {
        public static IFilterVisitor GetFlightsBeforeDate(DateTime dateTime)
        {
            return new GenericFilterVisitor(PredefinedFlightFilters.DepartureBeforeDate(dateTime));
        }

        public static IFilterVisitor GetFlightsBeforeNow()
        {
            return GenetricFilterVisitorFactory.GetFlightsBeforeDate(DateTime.Now);
        }


        public static IFilterVisitor GetFlightsWhereArrivalDateLessThenDeparture()
        {
            return new GenericFilterVisitor(PredefinedFlightFilters.DepartureAfterArrival);
        }
    }
}
