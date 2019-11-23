using BlueBoard.Service.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlueBoard.Identity.Controllers
{
    public class HomeController
    {
        private readonly IOptionsMonitor<ServiceOptions> options;

        public HomeController(IOptionsMonitor<ServiceOptions> options)
        {
            this.options = options;
        }

        [HttpGet("")]
        public string Index()
        {
            var current = this.options.CurrentValue;
            return $"Service {current.Name} v{current.Version}";
        }
    }
}
