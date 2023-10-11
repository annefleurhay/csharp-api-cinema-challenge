using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models { 

    [NotMapped]
    public class CustomerCollectionResponse
    {
        public string status { get; set; } = "success";

        public IEnumerable<Customer> data { get; set; }

    }
}
