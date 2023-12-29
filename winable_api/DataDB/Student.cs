using System;
using System.Collections.Generic;

namespace winable_api.DataDB
{
    public partial class Student
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? CollegeId { get; set; }

        public virtual College? College { get; set; }
    }
}
