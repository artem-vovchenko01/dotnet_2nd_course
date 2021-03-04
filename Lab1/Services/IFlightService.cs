using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IFlightService<Key> where Key : IComparable<Key> {
        void DelayFlight(Flight<Key> flight, int min);

        int SeatsAvailableCount(Flight<Key> flight);
        bool IsSeatAvailable(Flight<Key> flight, int seat);
        IList<int> SeatsAvailable(Flight<Key> flight);
    }
}
