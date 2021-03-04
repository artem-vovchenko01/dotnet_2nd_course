using System;

namespace Lab1 {
    interface IFlightDao<Key> : IAbstractDao<Flight<Key>, Key> where Key : IComparable<Key> {

    }
}

