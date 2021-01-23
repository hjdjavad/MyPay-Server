using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPay.Common.ErrorAndMessage;
using MyPay.Data.Database_Context;
using MyPay.Data.DTO.Site.Admin;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;
using MyPay.Services.Site.Admin.Auth.Inter;
// ReSharper disable All

namespace MyPay.UI.Controllers.Site.App
{
    [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MyPayDbContext> _db;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IUnitOfWork<MyPayDbContext> dbContext, IAuthService authService, IConfiguration config)
        {
            _db = dbContext;
            _authService = authService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExist(userForRegisterDto.UserName))
            {
                return BadRequest(new ReturnMessage()
                {
                    Status = false,
                    Title = "خطا",
                    Message = "این نام کاربری وجود دارد"
                });
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
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authService.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userFromRepo==null)
            {
                return Unauthorized(new ReturnMessage()
                {
                    Status = false,
                    Title = "خطا",
                    Message = "نام کاربری یا رمز عبور اشتباه است"
                });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescript = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = userForLoginDto.IsMember ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(2),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescript);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
