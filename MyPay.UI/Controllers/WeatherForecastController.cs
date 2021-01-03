using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyPay.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "value1", "value2" };
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
