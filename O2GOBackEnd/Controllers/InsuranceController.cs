using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/insurances")]
    [Produces("application/json")]
    [Authorize]
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        /// <summary>
        /// GET api/insurances
        /// </summary>
        /// <returns>insurances</returns>
        [HttpGet("")]
        public IActionResult GetInsurances()
        {
            return Ok(_insuranceService.GetInsurances());
        }

        /// <summary>
        /// POST api/insurances/create
        /// </summary>
        /// <param name="insurance"></param>
        /// <returns>insurance</returns>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateInsurance([FromBody] Insurance insurance)
        {
            var addedInsurance = _insuranceService.CreateInsurance(insurance);

            if (addedInsurance != null)
            {
                return Ok(insurance);
            }

            return BadRequest("Insurance couldn't be created.");
        }

        /// <summary>
        /// POST api/insurances/update
        /// </summary>
        /// <param name="insurance"></param>
        /// <returns>insurance</returns>
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateInsurance([FromBody] Insurance insurance)
        {
            var updatedInsurance = _insuranceService.UpdateInsurance(insurance);

            if (updatedInsurance != null)
            {
                return Ok(insurance);
            }

            return BadRequest("Insurance couldn't be updated.");
        }

        /// <summary>
        /// POST api/insurances/update
        /// </summary>
        /// <param name="insurance"></param>
        /// <returns>insurance</returns>
        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveInsurance([FromBody] Insurance insurance)
        {
            var removedInsurance = _insuranceService.RemoveInsurance(insurance);

            if (removedInsurance != null)
            {
                return Ok(insurance);
            }

            return BadRequest("Insurance couldn't be removed.");
        }
    }
}
