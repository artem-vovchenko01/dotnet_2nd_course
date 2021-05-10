using System.Collections.Generic;
using System;

namespace Lab1 {
    interface ITicketDao : IAbstractDao<Ticket, int> {
        IList<Ticket> GetTicketsByFlight(Flight flight);
    }
}
