using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyPay.Data.Models;

namespace MyPay.Services.Auth.Inter
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
    }
}
