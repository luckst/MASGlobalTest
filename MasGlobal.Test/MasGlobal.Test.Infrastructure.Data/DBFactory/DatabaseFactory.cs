namespace MasGlobal.Test.Infrastructure.Data.DBFactory
{
    using MasGlobal.Test.Infrastructure.Data.EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseFactory : IDatabaseFactory
    {
        private DBContext dataContext;
        public DbContext GetDatabase()
        {
            return dataContext ?? (dataContext = new DBContext());
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
