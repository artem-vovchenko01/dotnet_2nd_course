using System;
using System.Linq;
using System.Collections.Generic;
using System.CodeDom;

namespace Lab1 {
    class AbstractDao<T, Key> : IAbstractDao<T, Key> where T : IBase<Key> where Key : IComparable<Key> {
       protected IDictionary<Key, T> _entities;
       protected IDatabase<Key> _db;
       private Key _keySeed;
       private Key _lastKey;
       private Func<Key, Key> _keyGenerator;
       public AbstractDao(IDatabase<Key> database) {
          _db = database; 
          _keySeed = _lastKey = database.keySeed;
          _keyGenerator = database.keyGenerator;
       }
       public T Get(Key Id) {
           return _entities[Id];
       }

       public void Update(Key id, T entity) {
           if(_entities[id] != null) {
           entity.Id = id;
           _entities[id] = entity;
           } else throw new Exception("Passed key is not present in the database");
       }

       public void Add(T entity) {
           entity.Id = _lastKey;
           _entities[_lastKey] = entity;
           _lastKey = _keyGenerator(_lastKey);
       }

       public void Delete(Key id) {
           _entities.Remove(id);
       }

       public IList<T> GetAll() {
           return _entities.Values.ToList();
       }
    }
}
