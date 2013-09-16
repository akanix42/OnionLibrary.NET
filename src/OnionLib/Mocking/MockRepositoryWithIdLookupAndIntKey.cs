using System.Linq;

namespace LayeredDev.Mocking
{
    public class MockRepositoryWithIdLookupAndIntKey<T> : MockRepositoryWithIdLookup<T, int>, IMockRepositoryWithIdLookupAndIntKey<T> where T : IObjectWithId<int>
    {
        public override int GetNextKey()
        {
            return Dictionary.Any() ? (Dictionary.Max(x => x.Key) + 1) : 1;
        }
    }
}