using iFridge_Backend.Models.Foods;
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

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Bread> Breads { get; set; } = new List<Bread>();

        public ICollection<Fruit> Fruits { get; set; } = new List<Fruit>();

        public ICollection<Milk> Milks { get; set; } = new List<Milk>();

        public ICollection<Other> Others { get; set; } = new List<Other>();

        public ICollection<Seafood> Seafoods { get; set; } = new List<Seafood>();

        public ICollection<Spices> Spicess { get; set; } = new List<Spices>();

        public ICollection<Vegetable> Vegetables { get; set; } = new List<Vegetable>();
        public ICollection<UserFridge> UserFridges { get; set; } = new List<UserFridge>();


    }
}
