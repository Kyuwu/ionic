using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class Package
    {
        public Package()
        {
            Contracts = new HashSet<Contract>();
            PackageInsurances = new HashSet<PackageInsurance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<PackageInsurance> PackageInsurances { get; set; }
    }
}
