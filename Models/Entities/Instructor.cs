using System;
using System.Collections.Generic;

namespace ScaffoldDB.Models.Entities
{
    public partial class Instructor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
