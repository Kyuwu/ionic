using O2GOBackEnd.Models;
using O2GOBackEnd.Models.User;

namespace O2GOBackEnd.Services
{
    public class UserService : IUserService
    {
        private O2GOContext _context;

        public UserService(O2GOContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.ApplicationUsers.FirstOrDefault(u => u.UserId == id);
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            var userToUpdate = _context.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id);

            if (userToUpdate != null)
            {
                _context.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id).FirstName = user.FirstName;
                _context.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id).LastName = user.LastName;
                _context.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id).Address = user.Address;
                _context.SaveChanges();

                return user;
            }

            return null;
        }
    }
}
