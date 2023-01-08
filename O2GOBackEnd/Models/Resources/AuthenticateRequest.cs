using System.ComponentModel.DataAnnotations;

namespace O2GOBackEnd.Models.Resources
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
