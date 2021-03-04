using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class TicketDao : AbstractDao<Ticket<int>, int>, ITicketDao<int> {
        public TicketDao(IDatabase<int> database) : base(database) {
            _entities = _db.Tickets;
        }

        public IList<Ticket<int>> GetTicketsByFlight(Flight<int> flight) {
            return _entities.Values.Where(t => t.Flight == flight).ToList();
        }
    }
}
