using LayeredDev.DAL;

namespace LayeredDev.Mocking
{
    public interface IMockContext : IDalContext
    {
        void Init();
    }
}
