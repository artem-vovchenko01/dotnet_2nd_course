using System;

namespace Lab1 {
    class DaoFactory {
        public AirplaneDao AirplaneDao { get; }
        public AirportDao AirportDao { get; }
        public PassengerDao PassengerDao { get; }
        public FlightDao FlightDao { get; }
        public TicketDao TicketDao { get; }
        public RouteDao RouteDao { get; }
        public DaoFactory(Database database) {
            AirplaneDao = new AirplaneDao(database);
            AirportDao = new AirportDao(database);
            PassengerDao = new PassengerDao(database);
            FlightDao = new FlightDao(database);
            TicketDao = new TicketDao(database);
            RouteDao = new RouteDao(database);
        }
    }
}
