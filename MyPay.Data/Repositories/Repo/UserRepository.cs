using Microsoft.EntityFrameworkCore;
using MyPay.Data.Database_Context;
using MyPay.Data.Infrastructure;
using MyPay.Data.Models;
using MyPay.Data.Repositories.Inter;

namespace MyPay.Data.Repositories.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (_db ?? (MyPayDbContext) _db);
        }
    }
}
