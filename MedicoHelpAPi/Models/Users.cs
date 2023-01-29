using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
            Meeting = new HashSet<Meeting>();
        }

        public string Iduser { get; set; }
        public Guid RoleId { get; set; }

        [JsonIgnore]
        public virtual Roles Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Client> Client { get; set; }
        [JsonIgnore]
        public virtual ICollection<Clinic> Clinic { get; set; }
        [JsonIgnore]
        public virtual ICollection<Meeting> Meeting { get; set; }
    }
}
