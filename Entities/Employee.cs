using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldDB.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long Age { get; set; }

        [InverseProperty("Employee")]
        public virtual Studio Studio { get; set; } = null!;
        [InverseProperty(nameof(Album.Employee))]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
