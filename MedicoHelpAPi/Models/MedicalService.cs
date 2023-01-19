using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class MedicalService
    {
        public MedicalService()
        {
            ClinicalService = new HashSet<ClinicalService>();
        }

        public Guid IdmedicalService { get; set; }
        public Guid SubcategoryId { get; set; }
        public string ServiceName { get; set; }
        [JsonIgnore]
        public virtual Subcategory Subcategory { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClinicalService> ClinicalService { get; set; }
    }
}
