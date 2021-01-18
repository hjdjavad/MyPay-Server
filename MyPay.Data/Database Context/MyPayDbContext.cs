using Microsoft.EntityFrameworkCore;
using MyPay.Data.Models;

namespace MyPay.Data.Database_Context
{
    public class MyPayDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.;Initial Catalog=MyPayDB;Integrated Security=True;MultipleActiveResultSets=True;");
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
