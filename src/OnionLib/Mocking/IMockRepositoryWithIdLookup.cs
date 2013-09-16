using System.Collections.Generic;

namespace LayeredDev.Mocking
{
    public interface IMockRepositoryWithIdLookup<T, TKey> where T : IObjectWithId<TKey>
    {
        T Add(T item);
        TKey GetNextKey();
        bool Delete(TKey id);

        /// <summary>
        /// Return all users
        /// </summary>
        /// <returns></returns>
        List<T> Get();

        /// <summary>
        /// Return the specified user
        /// </summary>
        /// <returns></returns>
        T Get(TKey id);
    }
}