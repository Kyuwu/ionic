using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class PackageInsurance
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; } = null!;
        public virtual Package Package { get; set; } = null!;
    }
}
