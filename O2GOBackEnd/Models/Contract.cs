using System;
using System.Collections.Generic;
using O2GOBackEnd.Models.User;

namespace O2GOBackEnd.Models
{
    public partial class Contract
    {
        public Contract()
        {
            ContractInsurances = new HashSet<ContractInsurance>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PackageId { get; set; }
        public int ScooterId { get; set; }
        public int UserId { get; set; }

        public virtual Package Package { get; set; } = null!;
        public virtual Scooter Scooter { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<ContractInsurance> ContractInsurances { get; set; }
    }
}
