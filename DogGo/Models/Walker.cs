using System.ComponentModel.DataAnnotations;


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
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }      
    }
}
