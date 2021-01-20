using System.Threading.Tasks;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;

namespace MyPay.Repository.Repositories.Inter
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExist(string username);
    }
}
