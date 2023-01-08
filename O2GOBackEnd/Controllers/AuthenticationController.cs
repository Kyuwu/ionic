using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Models.User;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace O2GOBackEnd.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly O2GOContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, O2GOContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterResource userRegisterResource)
        {
            IdentityUser identityUser = null;
            identityUser = await _userManager.FindByEmailAsync(userRegisterResource.Email);

            if (identityUser != null)
            {
                return BadRequest($"Email {userRegisterResource.Email} already taken.");
            }

            var user = new IdentityUser { UserName = userRegisterResource.Email, Email = userRegisterResource.Email };
            var result = await _userManager.CreateAsync(user, userRegisterResource.Password);

            if (userRegisterResource.Admin)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            identityUser = await _userManager.FindByEmailAsync(userRegisterResource.Email);
            var applicationUser = new ApplicationUser()
            {
                FirstName = userRegisterResource.FirstName,
                LastName = userRegisterResource.LastName,
                UserId = identityUser.Id,

                Address = new Address()
                {
                    Street = userRegisterResource.Street,
                    Number = userRegisterResource.Housenumber,
                    PostalCode = userRegisterResource.PostalCode,
                    City = userRegisterResource.City
                }
            };

            _context.ApplicationUsers.Add(applicationUser);
            _context.SaveChanges();

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            userRegisterResource.Password = "Hidden";
            return Created("", userRegisterResource);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource loginResource)
        {
            var user = await _userManager.FindByEmailAsync(loginResource.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginResource.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(8),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    user,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
