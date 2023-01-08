using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models.User
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
