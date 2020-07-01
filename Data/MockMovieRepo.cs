using System;
using System.Collections.Generic;
using cs101_aspdotnet_web_api_movie.Models;

namespace cs101_aspdotnet_web_api_movie.Data
{
    public class MockMovieRepo : IMovieRepo
    {
        public IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 0, Title = "Crash Landing On You (2019)", ReleaseDate = new DateTime(2019, 12, 10), Genre = "Drama", Price = 0 },
                new Movie { Id = 1, Title = "Itaewon Class", ReleaseDate = new DateTime(2020, 1, 31), Genre = "Drama", Price = 0 },
                new Movie { Id = 2, Title = "Something In The Rain", ReleaseDate = new DateTime(2018, 3, 30), Genre = "Drama", Price = 0 },
            };

            return movies;
        }
        public Movie GetMovieById(int id)
        {
            return new Movie { Id = 0, Title = "Crash Landing On You (2019)", ReleaseDate = new DateTime(2019, 12, 10), Genre = "Drama", Price = 0 };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}