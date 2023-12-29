using System;
using System.Collections.Generic;

namespace winable_api.DataDB
{
    public partial class College
    {
        public College()
        {
            Students = new HashSet<Student>();
        }

        public long CollegeId { get; set; }
        public string? CollegeName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
