using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Samachar.Core
{
    /// <summary>
    /// Represents a Base Class for API Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }
    }
}
