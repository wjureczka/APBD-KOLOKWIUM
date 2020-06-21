using System.ComponentModel.DataAnnotations;


namespace APBD_KOLOKWIUM.Models
{
    public class Artist
    {
        [Key]
        public int IdArtist { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nickname { get; set; }
    }
}
