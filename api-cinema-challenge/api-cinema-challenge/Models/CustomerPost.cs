﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [NotMapped]
    public class CustomerPost
    {
        
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
