using System;
using System.Collections.Generic;
using O2GOBackEnd.Models.User;

namespace O2GOBackEnd.Models
{
    public partial class Address
    {
        public Address()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
            Servicepoints = new HashSet<Servicepoint>();
        }

        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public int Number { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Servicepoint> Servicepoints { get; set; }
    }
}
