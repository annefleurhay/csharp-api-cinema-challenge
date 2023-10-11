using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class TicketCollectionResponse
    {

        public string status { get; set; } = "success";

        public IEnumerable<Ticket> data { get; set; }
    }
}
