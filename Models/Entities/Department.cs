using System;
using System.Collections.Generic;

namespace ScaffoldDB.Models.Entities
{
    public partial class Department
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Hod { get; set; }
    }
}
