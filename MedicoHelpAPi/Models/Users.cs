using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Users
    {
        public Users()
        {
            Client = new HashSet<Client>();
            Clinic = new HashSet<Clinic>();
        }

        public Guid Iduser { get; set; }
        public Guid RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Clinic> Clinic { get; set; }
    }
}
