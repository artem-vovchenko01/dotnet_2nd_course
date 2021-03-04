using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IAbstractDao<T, Key> where T : IBase<Key> {
        T Get(Key Id);
        void Add(T entity);
        void Update(Key Id, T entity);
        void Delete(Key Id);
        IList<T> GetAll();
    }
}
