namespace LayeredDev.Mocking
{
    public interface IMockRepositoryWithIdLookupAndIntKey<T> :IMockRepositoryWithIdLookup<T, int> where T : IObjectWithId<int>
    {
    }
}
