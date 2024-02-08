using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFData.Entities
{
    [Table("Contacts")]
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(12)]
        [MinLength(9)]
        public string Phone { get; set; }

      
        public DateTime Birth { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

       
        
    }
}


