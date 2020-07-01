using System;

namespace cs101_aspdotnet_web_api_movie.DTOs
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
    }
}