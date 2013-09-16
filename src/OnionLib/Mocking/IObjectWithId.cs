namespace LayeredDev.Mocking
{
    public interface IObjectWithId<T>
    {
        T Id { get; set; }
    }
}