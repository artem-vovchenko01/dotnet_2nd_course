using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IFlightFilter<Key> where Key : IComparable<Key> {
        IList<Flight<Key>> Filter(IList<Flight<Key>> flights);
    }
}
