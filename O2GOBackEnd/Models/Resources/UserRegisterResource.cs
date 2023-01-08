using System.ComponentModel.DataAnnotations;

namespace O2GOBackEnd.Models.Resources
{
    public class UserRegisterResource
    {
        [Required(ErrorMessage = "E-mail is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "House number is required")]
        public int Housenumber { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        public bool Admin { get; set; }
    }
}
