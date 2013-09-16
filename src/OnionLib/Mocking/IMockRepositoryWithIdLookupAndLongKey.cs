namespace LayeredDev.Mocking
{
    public interface IMockRepositoryWithIdLookupAndLongKey<T> : IMockRepositoryWithIdLookup<T, long> where T : IObjectWithId<long>
    {
    }
}
