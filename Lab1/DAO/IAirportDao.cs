using System;

namespace Lab1 {
    interface IAirportDao<Key> : IAbstractDao<Airport<Key>, Key> where Key : IComparable<Key> {

    }
}
