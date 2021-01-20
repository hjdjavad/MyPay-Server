using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPay.Data.Database_Context;
using MyPay.Data.Models;
using MyPay.Repository.Infrastructure;
using MyPay.Services.Auth.Inter;

namespace MyPay.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUnitOfWork<MyPayDbContext> _db;
        private readonly IAuthService _authService;

        public WeatherForecastController(IUnitOfWork<MyPayDbContext> dbContext,IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            /*var user = new User()
            {
                Address = "",
                City = "",
                DateOfBirth = "",
                Gender = "",
                IsActive = true,
                Name = "",
                PasswordHash = new Byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new Byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PhoneNumber = "",
                Status = true,
                UserName = ""
            };*/
            return Ok("dsds");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string value)
        {
            return null;
        }

        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] string value)
        {
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return null;
        }
    }
}
