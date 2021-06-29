using Gridnine.FlightCodingTest.Interfaces;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors
{
    public class MultipleFilterVisitor : IFilterVisitor
    {
        private readonly IEnumerable<IFilterVisitor> _filterStrategies;
        public MultipleFilterVisitor(IEnumerable<IFilterVisitor> filterStrategies)
        {
            _filterStrategies = filterStrategies;
        }
        
        public IList<Flight> GetFlights(IList<Flight> flights)
        {
            IList<Flight> returnFlights = flights;
            foreach(IFilterVisitor filterStrategy in _filterStrategies)
            {
                returnFlights = filterStrategy.GetFlights(returnFlights);
            }
            return returnFlights;
        }
    }
}
