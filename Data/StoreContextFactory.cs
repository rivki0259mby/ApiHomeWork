using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class StoreContextFactory
    {
        private const string CnnectionString = "Server=DESKTOP-FM7OT9G;DataBase=StoreDb;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";
        public static StoreContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer(CnnectionString);
            return new StoreContext(optionsBuilder.Options);
        }
    }
}
