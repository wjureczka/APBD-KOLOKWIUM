using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD_KOLOKWIUM.Models
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }

        public ICollection<Artist_Event> EventArtists { get; set; }
    }
}
