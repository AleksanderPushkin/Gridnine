using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors
{
    public class GenericFilterVisitor: IFilterVisitor
    {
        private readonly Func<Flight, bool> _filter;
        public GenericFilterVisitor(Func<Flight, bool> filter)
        {
            _filter = filter;
        }

        public IList<Flight> GetFlights(IList<Flight> flights)
        {
            return flights.Where(_filter).ToList();
        }
    }
}
