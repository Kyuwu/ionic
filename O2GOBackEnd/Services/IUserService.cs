using O2GOBackEnd.Models.User;

namespace O2GOBackEnd.Services
{
    public interface IUserService
    {
        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
