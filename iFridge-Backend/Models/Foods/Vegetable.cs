using System;
using System.ComponentModel.DataAnnotations;

namespace iFridge_Backend.Models.Foods
{
    public class Vegetable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FridgeID { get; set; }

        [Required]
        public int OriginQTY { get; set; }

        [Required]
        public int CurrentQTY { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }
        public string Notes { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

    }
}
