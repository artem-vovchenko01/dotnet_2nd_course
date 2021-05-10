using System;

namespace Lab1 {
    interface IDaoFactory {
        IAirplaneDao AirplaneDao { get; }
        IAirportDao AirportDao { get; }
        IPassengerDao PassengerDao { get; }
        IFlightDao FlightDao { get; }
        ITicketDao TicketDao { get; }
        IRouteDao RouteDao { get; }
    }
}
