using System;
using System.Collections.Generic;

namespace ScaffoldDB.Models.Entities
{
    public partial class Student
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
