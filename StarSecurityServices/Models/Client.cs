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
        public string Company { get; set; }
        public string ServicesUsed { get; set; }
        public string AssignedStaff { get; set; }

        public virtual ICollection<Service>  Services{ get; set; }
    }
}
