using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOLOKWIUM.DTO.Requests
{
    public class UpdateArtistEventTimeRequest
    {
        [Required]
        public int IdArtist { get; set; }

        [Required]
        public int IdEvent { get; set; }

        [Required]
        public DateTime PerformanceDate { get; set; }
    }
}
