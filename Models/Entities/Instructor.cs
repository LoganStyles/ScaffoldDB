using System;
using System.Collections.Generic;

namespace ScaffoldDB.Models.Entities
{
    public partial class Instructor
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
    }
}
