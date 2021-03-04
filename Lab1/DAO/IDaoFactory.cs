using System;

namespace Lab1 {
    interface IDaoFactory<Key> where Key : IComparable<Key> {
        IAirplaneDao<Key> AirplaneDao { get; }
        IAirportDao<Key> AirportDao { get; }
        IPassengerDao<Key> PassengerDao { get; }
        IFlightDao<Key> FlightDao { get; }
        ITicketDao<Key> TicketDao { get; }
        IRouteDao<Key> RouteDao { get; }
    }
}
