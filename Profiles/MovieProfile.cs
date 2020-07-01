using AutoMapper;
using cs101_aspdotnet_web_api_movie.Models;
using cs101_aspdotnet_web_api_movie.DTOs;

namespace cs101_aspdotnet_web_api_movie.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieUpdateDTO, Movie>();
            CreateMap<Movie, MovieUpdateDTO>();
        }
    }
}