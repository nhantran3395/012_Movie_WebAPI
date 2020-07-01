using System.Collections.Generic;
using cs101_aspdotnet_web_api_movie.Models;

namespace cs101_aspdotnet_web_api_movie.Data
{
    public interface IMovieRepo
    {
        bool SaveChanges();
        public IEnumerable<Movie> GetMovies();
        public Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}