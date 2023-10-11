﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class MovieCollectionResponse
    {

        public string status { get; set; } = "success";
        public IEnumerable<Movie> data { get; set; }
    }
}
