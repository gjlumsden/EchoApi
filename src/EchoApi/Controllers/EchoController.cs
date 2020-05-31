using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace EchoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [HttpGet("{value}")]
        public EchoResponse Get(string value)
        {
            return new EchoResponse
            {
                EchoValue = value
            };
        }

        [HttpPost]
        public EchoResponse Post([FromBody] string value)
        {
            return new EchoResponse
            {
                EchoValue = value
            };
        }
    }

    public class EchoResponse
    {
        public string EchoValue { get; set; }
        public string OsInformation => RuntimeInformation.OSDescription;
        public string OsArchitecture => RuntimeInformation.OSArchitecture.ToString();
    }
}
