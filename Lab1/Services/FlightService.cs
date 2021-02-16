using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class FlightService {
        private DaoFactory db;
        private TicketService ticketService;
        public FlightService(DaoFactory factory) {
            db = factory;
            ticketService = new TicketService(db);
        }
        public void DelayFlight(Flight flight, int min) {
            flight.MinDelayed = min;
        }

        public int SeatsAvailableCount(Flight flight) {
            int max = flight.Route.Airplane.Seats;
            int occupied = 0;
            ticketService.SoldTickets(flight).ForEach(t => occupied += t.SeatsOccupied);
            return max - occupied;
        }

        public List<int> SeatsAvailable(Flight flight) {
            HashSet<int> avail = new HashSet<int>(Enumerable.Range(1, flight.Route.Airplane.Seats));
            foreach(Ticket t in ticketService.SoldTickets(flight)) {
                t.SeatsOccupiedList.ForEach(s => avail.Remove(s));
            }
            return avail.ToList();
        }
    }
}