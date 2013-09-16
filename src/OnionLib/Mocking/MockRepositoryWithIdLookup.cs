using System.Collections.Generic;
using System.Linq;

namespace LayeredDev.Mocking
{
    public abstract class MockRepositoryWithIdLookup<T, TKey> : IMockRepositoryWithIdLookup<T, TKey> where T : IObjectWithId<TKey>
    {
        public Dictionary<TKey, T> Dictionary = new Dictionary<TKey, T>();

        // Add a user to the DB
        public virtual T Add(T item)
        {
            lock (Dictionary)
            {
                item.Id = GetNextKey();
                Dictionary.Add(item.Id, item);
            }
            return item;
        }

        public abstract TKey GetNextKey();


        public virtual bool Delete(TKey id)
        {
            Dictionary.Remove(id);
            
            return true;
        }

        /// <summary>
        /// Return all users
        /// </summary>
        /// <returns></returns>
        public virtual List<T> Get()
        {
            return Dictionary
                .Select(x => x.Value)
                .ToList();
        }


        /// <summary>
        /// Return the specified user
        /// </summary>
        /// <returns></returns>
        public virtual T Get(TKey id)
        {
            T entry;
            Dictionary.TryGetValue(id, out entry);
            return entry;
        }
    }
}