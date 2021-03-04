using System;

namespace Lab1 {
    interface IPassengerDao<Key> : IAbstractDao<Passenger<Key>, Key> where Key : IComparable<Key> {

    }
}

