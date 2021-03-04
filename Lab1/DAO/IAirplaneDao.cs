using System;

namespace Lab1 {
    interface IAirplaneDao<Key> : IAbstractDao<Airplane<Key>, Key> where Key : IComparable<Key> {

    }
}
