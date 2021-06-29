using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gridnine.FlightCodingTest.Implementions.FlightWriter
{
    public class ConsoleFlightWriter : IFlightWriter
    { 
        public void Output(Flight flight)
        {
            Console.WriteLine("Flight: Departure Time - {0}, Arrival Time - {1} , Stops - {2}", flight.Segments.OrderBy(t => t.DepartureDate).First().DepartureDate, flight.Segments.OrderBy(t => t.ArrivalDate).Last().ArrivalDate, flight.Segments.Count - 1);
        }
    }
}
