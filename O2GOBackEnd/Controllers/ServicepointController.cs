using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/servicepoints")]
    [Produces("application/json")]
    [Authorize]
    public class ServicepointController : Controller
    {
        private readonly IServicepointService _servicepointService;

        public ServicepointController(IServicepointService servicepointService)
        {
            _servicepointService = servicepointService;
        }

        /// <summary>
        /// GET api/servicepoints
        /// </summary>
        /// <returns>servicepoints</returns>
        [HttpGet("")]
        public IActionResult GetServicepoints()
        {
            return Ok(_servicepointService.GetServicepoints());
        }

        /// <summary>
        /// POST api/servicepoints/create
        /// </summary>
        /// <param name="servicepoint"></param>
        /// <returns>servicepoint</returns>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateServicepoint([FromBody] Servicepoint servicepoint)
        {
            var addedServicepoint = _servicepointService.CreateServicepoint(servicepoint);

            if (addedServicepoint != null)
            {
                return Ok(servicepoint);
            }

            return BadRequest("Servicepoint couldn't be created.");
        }

        /// <summary>
        /// POST api/servicepoints/update
        /// </summary>
        /// <param name="servicepoint"></param>
        /// <returns>servicepoint</returns>
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateServicepoint([FromBody] Servicepoint servicepoint)
        {
            var updatedServicepoint = _servicepointService.UpdateServicepoint(servicepoint);

            if (updatedServicepoint != null)
            {
                return Ok(servicepoint);
            }

            return BadRequest("Servicepoint couldn't be updated.");
        }

        /// <summary>
        /// POST api/servicepoints/remove
        /// </summary>
        /// <param name="servicepoint"></param>
        /// <returns>servicepoint</returns>
        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveServicepoint([FromBody] Servicepoint servicepoint)
        {
            var removedServicepoint = _servicepointService.RemoveServicepoint(servicepoint);

            if (removedServicepoint != null)
            {
                return Ok(servicepoint);
            }

            return BadRequest("Servicepoint couldn't be removed.");
        }
    }
}
