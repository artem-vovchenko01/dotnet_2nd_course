using System;

namespace Lab1 {
    class DaoFactory : IDaoFactory {
        public IAirplaneDao AirplaneDao { get; }
        public IAirportDao AirportDao { get; }
        public IPassengerDao PassengerDao { get; }
        public IFlightDao FlightDao { get; }
        public ITicketDao TicketDao { get; }
        public IRouteDao RouteDao { get; }
        public DaoFactory(IDatabase<int> database) {
            AirplaneDao = new AirplaneDao(database);
            AirportDao = new AirportDao(database);
            PassengerDao = new PassengerDao(database);
            FlightDao = new FlightDao(database);
            TicketDao = new TicketDao(database);
            RouteDao = new RouteDao(database);
        }
    }
}
