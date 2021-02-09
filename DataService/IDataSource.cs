using System;
using System.Collections.Generic;

namespace DataService
{
    public interface IDataSource<T>
    {

        public void Add(T value);

        public T Remove(T value, Predicate<T> key);

        public T Update(T value, Predicate<T> key);

        public T Get(Predicate<T> key);

        public IEnumerable<T> GetALL();

        public void CommitAll(IEnumerable<T> all);

        public void CommitChanges();




    }
}
