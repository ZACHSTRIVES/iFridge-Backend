using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iFridge_Backend.Models
{
    public class UserFridge
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
        public int FridgeId { get; set; }
        public Fridge Fridge { get; set; }

    }
}
