using System.ComponentModel.DataAnnotations;

namespace iFridge_Backend.Models
{
    public class UserFridge
    {
        [Required]
        public int UserId { get; set; } 
        public User? User { get; set; }
        [Required]
        public int FridgeId { get; set; }
        public Fridge? Fridge { get; set; }

    }
}
