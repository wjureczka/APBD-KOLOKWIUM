using System.ComponentModel.DataAnnotations;

namespace APBD_KOLOKWIUM.Models
{
    public class Organiser
    {
        [Key]
        public int IdOrganiser { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
