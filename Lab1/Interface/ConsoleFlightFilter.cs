using System.Collections.Generic;
using System.Linq;
using System;

namespace Lab1 {
    class ConsoleFlightFilter : IFlightFilter {
        private DaoFactory db;
        private ItineraryService itineraryService;
        public ConsoleFlightFilter(DaoFactory factory) {
            db = factory;
            itineraryService = new ItineraryService(factory);
        }
        public List<IFlight> Filter(List<IFlight> flights) {
            List<IFlight> filteredFlights;
            string startDateStr;
            string endDateStr;
            Console.WriteLine("Search flights. Choose appropriate filters. Leave blank if defaults satisfy: ");
            Console.Write($"Start date (yyyy mm dd). Default: {DateTime.Today}: ");
            startDateStr = Console.ReadLine();
            Console.Write($"End date (yyyy mm dd). Default: {DateTime.Today.AddMonths(1)} : ");
            endDateStr = Console.ReadLine();
            Console.WriteLine();
            string[] split = startDateStr.Split(' ');
            DateTime startDate = startDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today;
            split = endDateStr.Split(' ');
            DateTime endDate = endDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today.AddMonths(1);
            filteredFlights = flights.Where(f => itineraryService.TimeDeparture(f) >= startDate && itineraryService.TimeDeparture(f) <= endDate).ToList();
            return filteredFlights;
        }
    }
}
