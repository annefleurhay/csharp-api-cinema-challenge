using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class ScreeningResponse
    {
        public string status { get; set; } = "success";

        public Screening data { get; set; }

    }
}
