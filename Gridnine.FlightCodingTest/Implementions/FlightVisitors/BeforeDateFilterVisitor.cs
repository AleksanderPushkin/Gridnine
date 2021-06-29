using Gridnine.FlightCodingTest.Implementions.FlightVisitors.Helpers;
using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors
{
    public class BeforeDateFilterVisitor : IFilterVisitor
    {
        private readonly DateTime _dateTime;
        private readonly Func<Flight, bool> _validator;

        public BeforeDateFilterVisitor(DateTime dateTime)
        {
            _dateTime = dateTime;
            _validator = PredefinedFlightFilters.DepartureBeforeDate(dateTime);
        }
        public IList<Flight> GetFlights(IList<Flight>  flights)
        {
            return flights.Where(_validator).ToList();
        }
    }
}
