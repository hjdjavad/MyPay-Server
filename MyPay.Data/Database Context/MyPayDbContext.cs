using Microsoft.EntityFrameworkCore;

namespace MyPay.Data.Database_Context
{
    class MyPayDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.;Initial Catalog=MyPayDB;Integrated Security=True;MultipleActiveResultSets=True;");
        }
    }
}
