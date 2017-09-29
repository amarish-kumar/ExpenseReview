using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ReimbursementApp.Controllers.API
{
    [Route("api/[controller]")]
    public class MenuAccessController : Controller
    {
        public MenuAccessController(IConfiguration configuration) => Config = configuration;
        public IConfiguration Config { get; set; }

        [HttpGet("")]
        public bool Get()
        {
            var windowsGroup = Config.GetSection("WindowsGroup")
                .GetSection("allowedUsers")
                .GetChildren()
                .Select(x => x.Value).ToArray();

            return windowsGroup.Contains(User.Identity.Name);
        }
    }
}
