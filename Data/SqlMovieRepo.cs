using System;
using System.Collections.Generic;
using System.Linq;
using cs101_aspdotnet_web_api_movie.Models;

namespace cs101_aspdotnet_web_api_movie.Data
{
    public class SqlMovieRepo : IMovieRepo
    {
        private readonly MoviesContext _context;
        public SqlMovieRepo(MoviesContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> GetMovies()
        {
            List<Movie> movies = _context.Movies.ToList();
            return movies;
        }
        public Movie GetMovieById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(item => item.Id == id);
            return movie;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            _context.Movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
        }

        public void DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(item => item.Id == id);
            _context.Movies.Remove(movie);
        }
    }
}