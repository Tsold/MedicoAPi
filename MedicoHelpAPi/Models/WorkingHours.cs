using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class WorkingHours
    {
        public Guid IdavailableTimeFrame { get; set; }
        public Guid WeekDayId { get; set; }
        public Guid Idclinic { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime Dateto { get; set; }

        public virtual Clinic IdclinicNavigation { get; set; }
        public virtual WeekDays WeekDay { get; set; }
    }
}
