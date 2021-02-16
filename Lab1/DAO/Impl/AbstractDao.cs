using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class AbstractDao<T> : IAbstractDao<T> where T : IBase {
       protected Dictionary<Guid, T> _entities;
       protected Database _db;
       public AbstractDao(Database database) {
          _db = database; 
       }
       public T Get(Guid Id) {
           return _entities[Id];
       }

       public void Update(Guid id, T entity) {
           entity.Id = id;
           _entities[id] = entity;
       }

       public void Add(T entity) {
           Guid id = Guid.NewGuid();
           entity.Id = id;
           _entities[id] = entity;
       }

       public void Delete(Guid id) {
           _entities.Remove(id);
       }

       public List<T> GetAll() {
           return _entities.Values.ToList();
       }
    }
}
