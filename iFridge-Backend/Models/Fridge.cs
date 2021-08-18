using System;
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

    }
}
