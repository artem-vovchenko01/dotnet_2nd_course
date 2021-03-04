using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class TicketDao<Key> : AbstractDao<Ticket<Key>, Key> where Key : IComparable<Key> {
        public TicketDao(IDatabase<Key> database) : base(database) {
            _entities = _db.Tickets;
        }

        public IList<Ticket<Key>> GetTicketsByFlight(Flight<Key> flight) {
            return _entities.Values.Where(t => t.Flight == flight).ToList();
        }
    }
}
