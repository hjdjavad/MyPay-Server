using Microsoft.EntityFrameworkCore;
using MyPay.Data.Database_Context;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;
using MyPay.Repository.Repositories.Inter;

namespace MyPay.Repository.Repositories.Repo
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
