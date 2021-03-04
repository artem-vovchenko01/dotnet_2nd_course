using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IInterface<Key> where Key : IComparable<Key> {
        void Begin();
        bool ChangeBookingDeadline(Flight<Key> flight);
        bool DelayFlight(Flight<Key> flight); 
        void ShowFlights(IList<Flight<Key>> flights);
        void ShowSoldTickets(Flight<Key> flight);
    }
}
