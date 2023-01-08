using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/services")]
    [Produces("application/json")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        /// <summary>
        /// GET api/services
        /// </summary>
        /// <returns>services</returns>
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetServices()
        {
            return Ok(_serviceService.GetServices());
        }

        /// <summary>
        /// POST api/services/create
        /// </summary>
        /// <param name="service"></param>
        /// <returns>service</returns>
        [HttpPost("create")]
        public IActionResult CreateService([FromBody] Service service)
        {
            var addedService = _serviceService.CreateService(service);

            if (addedService != null)
            {
                return Ok(service);
            }

            return BadRequest("Service couldn't be created.");
        }

        /// <summary>
        /// POST api/services/update
        /// </summary>
        /// <param name="service"></param>
        /// <returns>service</returns>
        [HttpPost("update")]
        public IActionResult UpdateService([FromBody] Service service)
        {
            var updatedService = _serviceService.UpdateService(service);

            if (updatedService != null)
            {
                return Ok(service);
            }

            return BadRequest("Service couldn't be updated.");
        }

        /// <summary>
        /// POST api/services/remove
        /// </summary>
        /// <param name="service"></param>
        /// <returns>service</returns>
        [HttpPost("remove")]
        public IActionResult RemoveService([FromBody] Service service)
        {
            var removedService = _serviceService.RemoveService(service);

            if (removedService != null)
            {
                return Ok(service);
            }

            return BadRequest("Service couldn't be removed.");
        }
    }
}
