using System.Threading.Tasks;
using MyPay.Common.Helpers;
using MyPay.Data.Database_Context;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;
using MyPay.Services.Site.Admin.Auth.Inter;

namespace MyPay.Services.Site.Admin.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork<MyPayDbContext> _db;

        public AuthService(IUnitOfWork<MyPayDbContext> dbContext)
        {
            _db = dbContext;
        }
        public async Task<User> Register(User user, string password)
        {
            Utility.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _db.UserRepository.GetAsync(p => p.UserName == username);
            if (user==null)
            {
                return null;
            }

            if (!Utility.VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }

            return user;
        }
    }
}
