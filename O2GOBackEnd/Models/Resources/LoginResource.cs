using System.ComponentModel.DataAnnotations;

namespace O2GOBackEnd.Models.Resources
{
    public class LoginResource
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
