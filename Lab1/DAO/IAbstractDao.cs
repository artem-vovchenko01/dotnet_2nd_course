using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IAbstractDao<T> where T : IBase {
        T Get(Guid Id);
        void Add(T entity);
        void Update(Guid Id, T entity);
        void Delete(Guid Id);
        List<T> GetAll();
    }
}
