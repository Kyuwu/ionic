using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/scooters")]
    [Produces("application/json")]
    [Authorize]
    public class ScooterController : Controller
    {
        private readonly IScooterService _scooterService;

        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        /// <summary>
        /// GET api/scooters
        /// </summary>
        /// <returns>scooters</returns>
        [HttpGet]
        public IActionResult GetScooters()
        {
            return Ok(_scooterService.GetScooters());
        }

        /// <summary>
        /// POST api/scooters/create
        /// </summary>
        /// <param name="scooter"></param>
        /// <returns>scooter</returns>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateScooter([FromBody] Scooter scooter)
        {
            var createdScooter = _scooterService.CreateScooter(scooter);

            if (createdScooter != null)
            {
                return Ok(createdScooter);
            }

            return BadRequest("Scooter couldn't be created");
        }

        /// <summary>
        /// POST api/scooters/update
        /// </summary>
        /// <param name="scooter"></param>
        /// <returns>scooter</returns>
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateScooter([FromBody] Scooter scooter)
        {
            var scooterToUpdate = _scooterService.UpdateScooter(scooter);

            if (scooterToUpdate != null)
            {
                return Ok(scooterToUpdate);
            }

            return BadRequest("Scooter couldn't be updated");
        }

        /// <summary>
        /// POST api/scooters/update
        /// </summary>
        /// <param name="scooter"></param>
        /// <returns>scooter</returns>
        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveScooter([FromBody] Scooter scooter)
        {
            var scooterToRemove = _scooterService.RemoveScooter(scooter);

            if (scooterToRemove != null)
            {
                return Ok("Scooter successfully removed.");
            }

            return BadRequest("Scooter couldn't be removed.");
        }

        /// <summary>
        /// GET api/scooters/get-by-availability
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>scooters</returns>
        [HttpGet("get-by-availability")]
        public IActionResult GetAvailableScootersByDates([FromBody] FromToInputModel inputModel)
        {
            return Ok(_scooterService.GetScootersByAvailability(inputModel.From, inputModel.To));
        }

        /// <summary>
        /// GET api/scooters/check-scooter-availability
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>scooter</returns>
        [HttpGet("check-scooter-availability")]
        public IActionResult CheckAvailability([FromBody] ScooterFromToInputModel inputModel)
        {
            var available = _scooterService.CheckAvailability(inputModel.Scooter, inputModel.From, inputModel.To);

            if (available)
            {
                return Ok($"Scooter with licenseplate:{inputModel.Scooter.LicensePlate} is available from {inputModel.From.ToString()} to {inputModel.To.ToString()}");
            }

            return BadRequest($"Scooter with licenseplate:{inputModel.Scooter.LicensePlate} is NOT available from {inputModel.From.ToString()} to {inputModel.To.ToString()}");
        }
    }
}
