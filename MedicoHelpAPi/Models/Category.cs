using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategory = new HashSet<Subcategory>();
        }

        public Guid Idcategory { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
