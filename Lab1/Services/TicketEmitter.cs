using System;
using System.Collections.Generic;

namespace Lab1 {
    class TicketEmitter {
        public Ticket<int> GetNewTicket(Passenger<int> passenger, int adults, int children, IList<int> seats, Flight<int> flight, IDaoFactory<int> db) {
            IFlightService<int> flightService = new FlightService(db);
            int avail;
            int adultAddPrice = 50, childrenAddPrice = 20;
            if (seats.Count != adults || children > adults || DateTime.Today > flight.StopBooking) return null;
            avail = flightService.SeatsAvailableCount(flight);
            foreach (int i in seats) if (! flightService.IsSeatAvailable(flight, i)) return null;
            return new Ticket<int> {Flight = flight, SeatsOccupiedList = seats, Adults = adults, Children = children, Passenger = passenger, SeatsOccupied = seats.Count, Price = flight.Route.Airplane.DefaultPrice + (adults - 1) * adultAddPrice + children * childrenAddPrice};
        }
    }
}
