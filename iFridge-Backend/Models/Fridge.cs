
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iFridge_Backend.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public ICollection<UserFridge> UserFridges { get; set; } = new List<UserFridge>();

        public ICollection<Food> Foods { get; set; } = new List<Food>();

       


    }
}
