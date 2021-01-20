using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPay.Data.Database_Context;
using MyPay.Data.DTO.Site.Admin;
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
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExist(userForRegisterDto.UserName))
            {
                return BadRequest("این نام کاربری وجود دارد");
            }
            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName,
                Name = userForRegisterDto.Name,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = "",
                City = "",
                DateOfBirth = DateTime.Now,
                Gender = true,
                IsActive = true,
                Status = true
            };
            var userCreated = await _authService.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
    }
}
