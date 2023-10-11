using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class TicketResponse
    {
        public string status { get; set; } = "success";

        public Ticket data { get; set; }


    }
}
