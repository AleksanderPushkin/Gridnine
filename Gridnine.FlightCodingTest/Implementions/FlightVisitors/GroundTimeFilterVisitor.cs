using Gridnine.FlightCodingTest.Helpers;
using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gridnine.FlightCodingTest.Implementions.FlightVisitors
{
    public class GroundTimeFilterVisitor : IFilterVisitor
    {
        private readonly TimeSpan _timeSpan;
        public GroundTimeFilterVisitor(int seconds)
        {
            _timeSpan = TimeSpan.FromSeconds(seconds);
        }

        public GroundTimeFilterVisitor(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        public GroundTimeFilterVisitor(int days = 0, int hours = 0 , int minutes = 0, int seconds = 0)
        {
            _timeSpan = new TimeSpan(days, hours, minutes, seconds);
        }

        public IList<Flight> GetFlights(IList<Flight> flights)
        {
            return flights.Where(t => t.Segments.Count > 1 && t.Segments.SelectPairs((a, b) => b.DepartureDate - a.ArrivalDate).SumWhile(TimeSpan.Zero, (i, a) => a = i + a, a =>   _timeSpan <= a)).ToList();
        }


    }


}
