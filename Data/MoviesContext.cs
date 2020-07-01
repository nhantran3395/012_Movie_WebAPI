using cs101_aspdotnet_web_api_movie.Models;
using Microsoft.EntityFrameworkCore;

namespace cs101_aspdotnet_web_api_movie.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}