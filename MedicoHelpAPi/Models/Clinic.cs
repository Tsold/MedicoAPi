using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            ClinicalService = new HashSet<ClinicalService>();
        }

        public Guid Idclinic { get; set; }
        public string UserId { get; set; }
        public string ClinicName { get; set; }
        public string ShortDes { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<ClinicalService> ClinicalService { get; set; }
    }
}
