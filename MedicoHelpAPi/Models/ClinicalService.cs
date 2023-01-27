using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class ClinicalService
    {
        public ClinicalService()
        {
            Meeting = new HashSet<Meeting>();
        }

        public Guid Idservice { get; set; }
        public Guid Idclinic { get; set; }
        public Guid MedicalServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ShortDes { get; set; }
        public decimal Price { get; set; }
        public string Preparation { get; set; }

        public virtual Clinic IdclinicNavigation { get; set; }
        public virtual MedicalService MedicalService { get; set; }
        public virtual ICollection<Meeting> Meeting { get; set; }
    }
}
