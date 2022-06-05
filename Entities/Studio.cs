using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldDB.Entities
{
    [Index(nameof(EmployeeId), IsUnique = true)]
    public partial class Studio
    {
        [Key]
        public long Id { get; set; }
        public long HouseNumber { get; set; }
        public string City { get; set; } = null!;
        public long EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Studio")]
        public virtual Employee Employee { get; set; } = null!;
    }
}
