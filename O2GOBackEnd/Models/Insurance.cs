using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class Insurance
    {
        public Insurance()
        {
            ContractInsurances = new HashSet<ContractInsurance>();
            PackageInsurances = new HashSet<PackageInsurance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<ContractInsurance> ContractInsurances { get; set; }
        public virtual ICollection<PackageInsurance> PackageInsurances { get; set; }
    }
}
