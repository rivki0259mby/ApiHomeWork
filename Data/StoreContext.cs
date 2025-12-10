using Microsoft.EntityFrameworkCore;
using WebApplication1.models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<MainCategory> MainCategories => Set<MainCategory>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<User> Users => Set<User>();

        public DbSet<Adress> Adresses => Set<Adress>();



    }
}
