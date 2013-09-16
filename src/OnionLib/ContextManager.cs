using LayeredDev.DAL;
using LayeredDev.Mocking;

namespace LayeredDev
{
    public class ContextManager<TDalContext, TMockContext>
        where TDalContext : class, IDalContext, new()
        where TMockContext : class, IMockContext, IDalContext, new()
    {
        private TDalContext _dbContext;
        private TMockContext _mockContext;

        # region Fields

        # endregion

        # region Properties
        string b;

        public TDalContext DalContext { get { return UseMocks ? MockContext as TDalContext : DbContext; } }

        public TDalContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new TDalContext()); }
        }

        public TMockContext MockContext
        {
            get { return _mockContext ?? (_mockContext = new TMockContext()); }
        }

        public bool UseMocks { get; set; }

        # endregion

    }
}
