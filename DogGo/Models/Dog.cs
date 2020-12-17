using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "What do you call your dog?")]
        [MaxLength(35)]
        public string Name { get; set; }
        
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "We need to know doggos breed")]
        public string Breed { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        public Owner Owner { get; set; }
    }
}
