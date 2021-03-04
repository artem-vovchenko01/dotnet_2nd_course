using System;

namespace Lab1 {
    class DaoFactory : IDaoFactory<int> {
        public IAirplaneDao<int> AirplaneDao { get; }
        public IAirportDao<int> AirportDao { get; }
        public IPassengerDao<int> PassengerDao { get; }
        public IFlightDao<int> FlightDao { get; }
        public ITicketDao<int> TicketDao { get; }
        public IRouteDao<int> RouteDao { get; }
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
