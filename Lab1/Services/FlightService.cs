using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class FlightService<Key> : IFlightService<Key> where Key : IComparable<Key> {
        private IDaoFactory<Key> db;
        private TicketService<Key> ticketService;
        public FlightService(IDaoFactory<Key> factory) {
            db = factory;
            ticketService = new TicketService<Key>(db);
        }
        public void DelayFlight(Flight<Key> flight, int min) {
            flight.MinDelayed = min;
        }

        public int SeatsAvailableCount(Flight<Key> flight) {
            int max = flight.SeatsCapacity;
            int occupied = 0;
            foreach (Ticket<Key> t in ticketService.SoldTickets(flight)) occupied += t.SeatsOccupied;
            return max - occupied;
        }
        public bool IsSeatAvailable(Flight<Key> flight, int seat) {
            IList<int> avail = SeatsAvailable(flight);
            return avail.Contains(seat);
        }
        public IList<int> SeatsAvailable(Flight<Key> flight) {
            HashSet<int> avail = new HashSet<int>(Enumerable.Range(1, flight.Route.Airplane.Seats));
            foreach(Ticket<Key> t in ticketService.SoldTickets(flight)) {
                foreach(int s in t.SeatsOccupiedList) avail.Remove(s);
            }
            return avail.ToList();
        }
    }
}