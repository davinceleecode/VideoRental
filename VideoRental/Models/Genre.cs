using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace VideoRental.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}