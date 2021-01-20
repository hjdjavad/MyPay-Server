using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPay.Data.Database_Context;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;
using MyPay.Services.Site.Admin.Auth.Inter;
// ReSharper disable All

namespace MyPay.UI.Controllers.Site.App
{
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MyPayDbContext> _db;
        private readonly IAuthService _authService;

        public AuthController(IUnitOfWork<MyPayDbContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }
        public async Task<IActionResult> Register(string userName,string password)
        {
            userName = userName.ToLower();
            if (await _db.UserRepository.UserExist(userName))
            {
                return BadRequest("این نام کاربری وجود دارد");
            }
            var userToCreate = new User
            {
                UserName = userName,
                Address = "",
                City = "",
                DateOfBirth = "",
                Gender = "",
                IsActive = true,
                Name = "",
                PhoneNumber = "",
                Status = true
            };
            var userCreated = await _authService.Register(userToCreate, password);
            return StatusCode(201);
        }
    }
}
