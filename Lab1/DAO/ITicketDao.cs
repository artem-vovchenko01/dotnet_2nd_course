using System.Collections.Generic;
using System;

namespace Lab1 {
    interface ITicketDao<Key> : IAbstractDao<Ticket<Key>, Key> where Key : IComparable<Key> {
        List<Ticket<Key>> GetTicketsByFlight(Flight<Key> flight);
    }
}
