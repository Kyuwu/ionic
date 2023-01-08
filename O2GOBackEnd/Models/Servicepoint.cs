using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class Servicepoint
    {
        public Servicepoint()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Service> Services { get; set; }
    }
}
