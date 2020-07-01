using System;
using System.ComponentModel.DataAnnotations;

namespace cs101_aspdotnet_web_api_movie.DTOs
{
    public class MovieCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}