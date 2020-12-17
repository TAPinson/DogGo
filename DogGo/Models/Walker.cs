using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(55)]
        public string Name { get; set; }

        [Required(ErrorMessage = "What area do you walk in?")]
        public int NeighborhoodId { get; set; }

        [Required(ErrorMessage = "Need an image please")]
        public string ImageUrl { get; set; }

        public Neighborhood Neighborhood { get; set; }      
    }
}
