using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class TicketDao : AbstractDao<Ticket, int>, ITicketDao {
        public TicketDao(IDatabase database) : base(database) {
            _entities = _db.Tickets;
        }

        public IList<Ticket> GetTicketsByFlight(Flight flight) {
            return _entities.Values.Where(t => t.Flight == flight).ToList();
        }
    }
}
