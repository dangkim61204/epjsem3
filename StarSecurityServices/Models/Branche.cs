using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityServices.Models
{
    [Table("Branches")]
    public class Branche
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Description { get; set; }
        public string? GoogleMap { get; set; }
      
    }
}
