using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;
using System.Security.Claims;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    [Produces("application/json")]
    [Authorize]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        /// <summary>
        /// GET api/contracts
        /// </summary>
        /// <returns>contracts</returns>
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetContracts()
        {
            return Ok(_contractService.GetContracts());
        }

        /// <summary>
        /// GET api/contracts/get-for-current-user
        /// </summary>
        /// <returns>contracts</returns>
        [HttpGet("get-for-current-user")]
        public IActionResult GetContractsByUser()
        {
            var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null) return NotFound();
            return Ok(_contractService.GetContractsForUser(user));
        }

        /// <summary>
        /// POST api/contracts/create
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>contract</returns>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            var addedContract = _contractService.CreateContract(contract);

            if (addedContract != null)
            {
                return Ok(contract);
            }

            return BadRequest("Contract couldn't be created.");
        }

        /// <summary>
        /// POST api/contracts/update
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>contract</returns>
        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateContract([FromBody] Contract contract)
        {
            var updatedContract = _contractService.UpdateContract(contract);

            if (updatedContract != null)
            {
                return Ok(contract);
            }

            return BadRequest("Contract couldn't be updated.");
        }

        /// <summary>
        /// POST api/contracts/remove
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>contract</returns>
        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveContract([FromBody] Contract contract)
        {
            var removedContract = _contractService.RemoveContract(contract);

            if (removedContract != null)
            {
                return Ok(contract);
            }

            return BadRequest("Contract couldn't be removed.");
        }
    }
}
