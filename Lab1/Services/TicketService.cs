using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class TicketService : ITicketService<int> {
        private IDaoFactory<int> db;
        public TicketService(IDaoFactory<int> factory) {
            db = factory;
        }

        public int SoldTicketsCount(Flight<int> flight) {
            return db.TicketDao.GetTicketsByFlight(flight).Count();
        }

        public IList<Ticket<int>> SoldTickets(Flight<int> flight) {
            return db.TicketDao.GetTicketsByFlight(flight);
        }
    }
}
