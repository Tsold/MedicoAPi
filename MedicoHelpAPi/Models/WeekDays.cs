using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class WeekDays
    {
        public WeekDays()
        {
            WorkingHours = new HashSet<WorkingHours>();
        }

        public Guid IdweekDays { get; set; }
        public string DayName { get; set; }

        public virtual ICollection<WorkingHours> WorkingHours { get; set; }
    }
}
