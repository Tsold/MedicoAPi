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
        public Guid Idservice { get; set; }
        public Guid Idclinic { get; set; }
        public Guid SubcategoryId { get; set; }
        public string ServiceName { get; set; }
        public string ShortDes { get; set; }
        public decimal Price { get; set; }
        public string Preparation { get; set; }

        [JsonIgnore]
        public virtual Clinic IdclinicNavigation { get; set; }
        [JsonIgnore]
        public virtual Subcategory Subcategory { get; set; }
    }
}
