using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class FlightService : IFlightService<int> {
        private IDaoFactory<int> db;
        private ITicketService<int> ticketService;
        public FlightService(IDaoFactory<int> factory) {
            db = factory;
            ticketService = new TicketService(db);
        }
        public void DelayFlight(Flight<int> flight, int min) {
            flight.MinDelayed = min;
        }

        public int SeatsAvailableCount(Flight<int> flight) {
            int max = flight.SeatsCapacity;
            int occupied = 0;
            foreach (Ticket<int> t in ticketService.SoldTickets(flight)) occupied += t.SeatsOccupied;
            return max - occupied;
        }
        public bool IsSeatAvailable(Flight<int> flight, int seat) {
            IList<int> avail = SeatsAvailable(flight);
            return avail.Contains(seat);
        }
        public IList<int> SeatsAvailable(Flight<int> flight) {
            HashSet<int> avail = new HashSet<int>(Enumerable.Range(1, flight.Route.Airplane.Seats));
            foreach(Ticket<int> t in ticketService.SoldTickets(flight)) {
                foreach(int s in t.SeatsOccupiedList) avail.Remove(s);
            }
            return avail.ToList();
        }
    }
}