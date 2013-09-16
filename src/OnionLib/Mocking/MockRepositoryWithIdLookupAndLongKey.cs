using System.Linq;

namespace LayeredDev.Mocking
{
    public class MockRepositoryWithIdLookupAndLongKey<T> : MockRepositoryWithIdLookup<T, long>, 
        IMockRepositoryWithIdLookupAndLongKey<T>
        where T : IObjectWithId<long>
    {
        public override long GetNextKey()
        {
            return Dictionary.Any() ? (Dictionary.Max(x => x.Key) + 1) : 1;
        }
    }
}