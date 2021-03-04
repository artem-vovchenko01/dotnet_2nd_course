using System;

namespace Lab1 {
    class DaoFactory<Key> : IDaoFactory<Key> where Key : IComparable<Key> {
        public AirplaneDao<Key> AirplaneDao { get; }
        public AirportDao<Key> AirportDao { get; }
        public PassengerDao<Key> PassengerDao { get; }
        public FlightDao<Key> FlightDao { get; }
        public TicketDao<Key> TicketDao { get; }
        public RouteDao<Key> RouteDao { get; }
        public DaoFactory(IDatabase<Key> database) {
            AirplaneDao = new AirplaneDao<Key>(database);
            AirportDao = new AirportDao<Key>(database);
            PassengerDao = new PassengerDao<Key>(database);
            FlightDao = new FlightDao<Key>(database);
            TicketDao = new TicketDao<Key>(database);
            RouteDao = new RouteDao<Key>(database);
        }
    }
}
