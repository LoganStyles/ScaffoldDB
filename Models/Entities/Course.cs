using System;
using System.Collections.Generic;

namespace ScaffoldDB.Models.Entities
{
    public partial class Course
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public long InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; } = null!;
    }
}
