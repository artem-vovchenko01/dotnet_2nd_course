using System.Collections.Generic;
using System.Linq;
using System;

namespace Lab1 {
    class ConsoleFlightFilter {
        private DaoFactory db;
        public ConsoleFlightFilter(DaoFactory factory) {
            db = factory;
        }
        public List<Flight> Filter(List<Flight> flights) {
            List<Flight> filteredFlights;
            string startDateStr;
            string endDateStr;
            Console.WriteLine("Search flights. Choose appropriate filters. Leave blank if defaults satisfy: ");
            Console.Write($"Start date (yyyy mm dd). Default: {DateTime.Now} (now): ");
            startDateStr = Console.ReadLine();
            Console.Write($"End date (yyyy mm dd). Default: {DateTime.Now.AddMonths(1)} : ");
            endDateStr = Console.ReadLine();
            Console.WriteLine();
            string[] split = startDateStr.Split(' ');
            DateTime startDate = startDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today;
            split = endDateStr.Split(' ');
            DateTime endDate = endDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today.AddMonths(1);
            filteredFlights = flights.Where(f => f.TimeDepart >= startDate && f.TimeDepart <= endDate).ToList();
            return filteredFlights;
        }
    }
}
