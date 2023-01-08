using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class Scooter
    {
        public Scooter()
        {
            Contracts = new HashSet<Contract>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public int MaxKmh { get; set; }
        public string Brand { get; set; } = null!;
        public int Year { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
