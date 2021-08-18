using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;


namespace iFridge_Backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string GitHub { get; set; }

        public string ImageURI { get; set; }

        public ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();


    }
}
