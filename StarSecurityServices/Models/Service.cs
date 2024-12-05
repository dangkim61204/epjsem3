using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityServices.Models
{
    [Table("Services")]
    public class Service
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public int ServiceId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
