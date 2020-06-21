using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOKWIUM.Models
{
    public class Artist_Event
    {
        public int IdEvent { get; set; }

        [ForeignKey("IdEvent")]
        public Event Event { get; set; }

        public int IdArtist { get; set; }

        [ForeignKey("IdArtist")]
        public Artist Artist { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
