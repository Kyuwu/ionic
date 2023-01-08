using System;
using System.Collections.Generic;

namespace O2GOBackEnd.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int ServicepointId { get; set; }
        public DateTime Date { get; set; }
        public int ScooterId { get; set; }

        public virtual Scooter Scooter { get; set; } = null!;
        public virtual Servicepoint Servicepoint { get; set; } = null!;
    }
}
