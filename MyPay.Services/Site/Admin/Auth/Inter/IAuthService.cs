using System.Threading.Tasks;
using MyPay.Data.Models;

namespace MyPay.Services.Site.Admin.Auth.Inter
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
    }
}
