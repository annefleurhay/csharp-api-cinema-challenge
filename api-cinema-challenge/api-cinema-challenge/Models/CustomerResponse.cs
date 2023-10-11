using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class CustomerResponse
    {
        public string status { get; set; } = "success";

        public Customer data {  get; set; }  



    }
}
