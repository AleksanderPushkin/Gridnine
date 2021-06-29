using Gridnine.FlightCodingTest.Implementions;
using Gridnine.FlightCodingTest.Implementions.FlightVisitors;
using Gridnine.FlightCodingTest.Implementions.FlightWriter;
using Gridnine.FlightCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            DateTime now = DateTime.Now;
            var flights  = flightBuilder.GetFlights();

            IFlightWriter flightWriter = new ConsoleFlightWriter();

            var flightsBeforeNow =   flightBuilder.GetFlightsByFilter(GenetricFilterVisitorFactory.GetFlightsBeforeNow());
            PrintFlights(flightsBeforeNow, flightWriter, "Вылет до текущего момента времени");

            //var flightsBeforeNow =   flightBuilder.GetFlightsByFilter(GenetricFilterVisitorFactory.GetFlightsBeforeDate(now));
            //PrintFlights(flightsBeforeNow, flightWriter, "Вылет до текущего момента времени");

            var flightsWhereArrivalDateLessThenDeparture = flightBuilder.GetFlightsByFilter(GenetricFilterVisitorFactory.GetFlightsWhereArrivalDateLessThenDeparture());
            PrintFlights(flightsWhereArrivalDateLessThenDeparture, flightWriter, "Имеются сегменты с датой прилёта раньше даты вылета");

          
            var flightsWhereSumOfGroundTimeMoreThenTwoHours = flightBuilder.GetFlightsByFilter(new GroundTimeFilterVisitor(0,2,0,0));
            PrintFlights(flightsWhereSumOfGroundTimeMoreThenTwoHours, flightWriter, "Общее время, проведённое на земле превышает два часа");

            Console.ReadKey();
         }


        private static void PrintFlights(IList<Flight> flights,IFlightWriter flightWriter, string filterType)
        {
            Console.WriteLine("------Filter Type: {0}-------------", filterType);
            flights.ToList().ForEach(t => flightWriter.Output(t));
            Console.WriteLine("---------------------------------");
        }
    }
}
