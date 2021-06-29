using System;
using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest.Interfaces
{
    public interface IFilterVisitor
    {
        IList<Flight> GetFlights(IList<Flight> flights);
    }
}
