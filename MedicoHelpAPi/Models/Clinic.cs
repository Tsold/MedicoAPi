using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            MedicalService = new HashSet<MedicalService>();
        }

        public Guid Idclinic { get; set; }
        public Guid UserId { get; set; }
        public string ClinicName { get; set; }
        public string ShortDes { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public virtual Users User { get; set; }
        [JsonIgnore]
        public virtual ICollection<MedicalService> MedicalService { get; set; }
    }
}
