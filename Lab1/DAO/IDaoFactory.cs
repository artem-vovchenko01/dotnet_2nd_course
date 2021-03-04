using System;

namespace Lab1 {
    interface IDaoFactory<Key> where Key : IComparable<Key> {
        AirplaneDao<Key> AirplaneDao { get; }
        AirportDao<Key> AirportDao { get; }
        PassengerDao<Key> PassengerDao { get; }
        FlightDao<Key> FlightDao { get; }
        TicketDao<Key> TicketDao { get; }
        RouteDao<Key> RouteDao { get; }
    }
}
