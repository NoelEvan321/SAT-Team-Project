using System;
using System.Collections.Generic;

namespace SAT_Team_Development.DATA.EF.Models
{
    public partial class ScheduledClassStatus
    {
        public ScheduledClassStatus()
        {
            ScheduledClasses = new HashSet<ScheduledClass>();
        }

        public int Scsid { get; set; }
        public string Scsname { get; set; } = null!;

        public virtual ICollection<ScheduledClass> ScheduledClasses { get; set; }
    }
}
