using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EchoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        private readonly IActionContextAccessor accessor;

        public EchoController(IActionContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        [HttpGet("{value}")]
        public EchoResponse Get(string value)
        {
            return new EchoResponse
            {
                EchoValue = value,
                CallerIpAddress = GetCallerIpAddress()
            };
        }

        private string GetCallerIpAddress()
        {
            return accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.IsIPv4MappedToIPv6 ? accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() : accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        [HttpPost]
        public EchoResponse Post([FromBody] string value)
        {
            return new EchoResponse
            {
                EchoValue = value,
                CallerIpAddress = GetCallerIpAddress()
            };
        }
    }

    public class EchoResponse
    {
        public string EchoValue { get; set; }
        public string OsInformation => RuntimeInformation.OSDescription;
        public string OsArchitecture => RuntimeInformation.OSArchitecture.ToString();
        public string CallerIpAddress { get; internal set; }
    }
}
