using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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

        public ICollection<UserFridge> UserFridges { get; set; } = new List<UserFridge>();


    }
}
