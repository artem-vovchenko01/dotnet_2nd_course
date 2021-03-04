using System;
using System.Collections.Generic;

namespace Lab1 {
    interface ITicketService<Key> where Key : IComparable<Key> {
        int SoldTicketsCount(Flight<Key> flight);
        IList<Ticket<Key>> SoldTickets(Flight<Key> flight);
    }
}
