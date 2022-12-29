﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public Guid Idrole { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Users> Users { get; set; }
    }
}
