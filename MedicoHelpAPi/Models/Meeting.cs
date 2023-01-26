using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class Meeting
    {
        public string MeetingId { get; set; }
        public Guid ServiceId { get; set; }
        public string UserId { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime Dateto { get; set; }
        public string EventName { get; set; }

        public virtual ClinicalService Service { get; set; }
        public virtual Users User { get; set; }
    }
}
