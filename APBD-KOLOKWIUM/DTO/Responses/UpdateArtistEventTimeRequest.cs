using System;
using System.ComponentModel.DataAnnotations;


namespace APBD_KOLOKWIUM.DTO.Responses
{
    public class UpdateArtistEventTimeResponse
    {
        public int IdArtist { get; set; }

        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
