using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.User;
using O2GOBackEnd.Services;
using System.Data;

namespace O2GOBackEnd.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Produces("application/json")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public UserController(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }

        /// <summary>
        /// GET api/users
        /// </summary>
        /// <returns>user</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUser(string id)
        {
            return Ok(_userService.GetUser(id));
        }

        /// <summary>
        /// POST api/users/update
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user</returns>
        [HttpPost("update")]
        [Authorize]
        public IActionResult UpdateUser([FromBody] ApplicationUser user)
        {
            var updatedUser = _userService.UpdateUser(user);

            if (updatedUser != null)
            {
                return Ok(updatedUser);
            }

            return BadRequest("User couldn't be updated.");
        }

        /// <summary>
        /// GET api/users/address
        /// </summary>
        /// <returns>address</returns>
        [HttpGet("address/{id}")]
        [Authorize]
        public IActionResult GetAddress(int id)
        {
            return Ok(_addressService.GetAddress(id));
        }

        /// <summary>
        /// POST api/users/address/update
        /// </summary>
        /// <returns>address</returns>
        [HttpPost("address/update")]
        [Authorize]
        public IActionResult UpdateAddress([FromBody] Address address)
        {
            return Ok(_addressService.UpdateAddress(address));
        }
    }
}
