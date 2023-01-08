using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class ContractInsurance
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int InsuranceId { get; set; }

        public virtual Contract Contract { get; set; } = null!;
        public virtual Insurance Insurance { get; set; } = null!;
    }
}
