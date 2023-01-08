using Microsoft.AspNetCore.Identity;

namespace O2GOBackEnd.Models.Resources
{
    public class AuthenticateResponseModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponseModel(IdentityUser user, string token)
        {
            Id = user.Id;
            Username = user.UserName;
            Token = token;
        }
    }
}
