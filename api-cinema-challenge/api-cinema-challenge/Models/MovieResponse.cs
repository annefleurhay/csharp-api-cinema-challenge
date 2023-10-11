using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class MovieResponse
    {

        public string status { get; set; } = "success";
        public Movie data { get; set; }

    }
}
