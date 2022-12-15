using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            MedicalService = new HashSet<MedicalService>();
        }

        public Guid Idsubcategory { get; set; }
        public string SubcategoryName { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<MedicalService> MedicalService { get; set; }
    }
}
