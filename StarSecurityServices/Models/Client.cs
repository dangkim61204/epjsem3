using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityServices.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email     { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        // Khóa ngoại đến Service

        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ICollection<ClientEmployee>? ClientEmployees { get; set; }

        public List<int> EmployeeIds { get; set; } = new List<int>();

    }
}
