using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/packages")]
    [Produces("application/json")]
    [Authorize]
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        /// <summary>
        /// GET api/packages
        /// </summary>
        /// <returns>packages</returns>
        [HttpGet("")]
        public IActionResult GetPackages()
        {
            return Ok(_packageService.GetPackages());
        }

        /// <summary>
        /// POST api/packages/create
        /// </summary>
        /// <param name="package"></param>
        /// <returns>package</returns>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreatePackage([FromBody] Package package)
        {
            var addedPackage = _packageService.CreatePackage(package);

            if (addedPackage != null)
            {
                return Ok(package);
            }

            return BadRequest("Package couldn't be created.");
        }

        /// <summary>
        /// POST api/packages/update
        /// </summary>
        /// <param name="package"></param>
        /// <returns>package</returns>
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePackage([FromBody] Package package)
        {
            var updatedPackage = _packageService.UpdatePackage(package);

            if (updatedPackage != null)
            {
                return Ok(package);
            }

            return BadRequest("Package couldn't be updated.");
        }

        /// <summary>
        /// POST api/packages/delete
        /// </summary>
        /// <param name="package"></param>
        /// <returns>package</returns>
        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemovePackage([FromBody] Package package)
        {
            var removedPackage = _packageService.RemovePackage(package);

            if (removedPackage != null)
            {
                return Ok(package);
            }

            return BadRequest("Package couldn't be removed.");
        }
    }
}
