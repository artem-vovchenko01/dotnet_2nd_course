using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class TicketDao : AbstractDao<Ticket>, ITicketDao {
        public TicketDao(Database database) : base(database) {
            _entities = _db.Tickets;
        }

        public List<Ticket> GetTicketsByFlight(Flight flight) {
            return _entities.Values.Where(t => t.Flight == flight).ToList();
        }
    }
}
