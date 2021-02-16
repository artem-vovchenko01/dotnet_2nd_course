using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class TicketService {
        private DaoFactory db;
        public TicketService(DaoFactory factory) {
            db = factory;
        }

        public int SoldTicketsCount(Flight flight) {
            return db.TicketDao.GetTicketsByFlight(flight).Count();
        }

        public List<Ticket> SoldTickets(Flight flight) {
            return db.TicketDao.GetTicketsByFlight(flight);
        }
    }
}
