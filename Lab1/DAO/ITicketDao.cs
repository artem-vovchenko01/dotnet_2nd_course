using System.Collections.Generic;

namespace Lab1 {
    interface ITicketDao : IAbstractDao<Ticket> {
        List<Ticket> GetTicketsByFlight(IFlight flight);
    }
}