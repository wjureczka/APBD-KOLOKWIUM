using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOKWIUM.Models
{
    public class Event_Organiser
    {
        public int IdEvent { get; set; }

        [ForeignKey("IdEvent")]
        public Event Event { get; set; }

        public int IdOrganiser { get; set; }

        [ForeignKey("IdOrganiser")]
        public Organiser Organiser { get; set; }
    }
}
