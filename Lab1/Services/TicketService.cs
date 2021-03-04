using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class TicketService<Key> : ITicketService<Key> where Key : IComparable<Key> {
        private IDaoFactory<Key> db;
        public TicketService(IDaoFactory<Key> factory) {
            db = factory;
        }

        public int SoldTicketsCount(Flight<Key> flight) {
            return db.TicketDao.GetTicketsByFlight(flight).Count();
        }

        public IList<Ticket<Key>> SoldTickets(Flight<Key> flight) {
            return db.TicketDao.GetTicketsByFlight(flight);
        }
    }
}
