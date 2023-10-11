using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class ScreeningCollectionResponse
    {

        public string status { get; set; } = "success";

        public IEnumerable<Screening> data { get; set; }
    }
}
