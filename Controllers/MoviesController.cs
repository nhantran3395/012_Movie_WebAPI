using System.Collections.Generic;
using AutoMapper;
using cs101_aspdotnet_web_api_movie.Data;
using cs101_aspdotnet_web_api_movie.DTOs;
using cs101_aspdotnet_web_api_movie.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace cs101_aspdotnet_web_api_movie.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _repository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDTO>> GetMovies()
        {
            var movies = _repository.GetMovies();
            return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(movies));
        }
        [HttpGet("{id}", Name = ("GetMovieById"))]
        public ActionResult<MovieReadDTO> GetMovieById(int id)
        {
            var movie = _repository.GetMovieById(id);
            if (movie != null)
            {
                return Ok(_mapper.Map<MovieReadDTO>(movie));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MovieReadDTO> CreateMovie(MovieCreateDTO movieCreateDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreateDTO);
            _repository.CreateMovie(movie);
            _repository.SaveChanges();
            var movieReadDTO = _mapper.Map<MovieReadDTO>(movie);
            return CreatedAtRoute(nameof(GetMovieById), new { Id = movieReadDTO.Id }, movieReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var movieFromDb = _repository.GetMovieById(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            _mapper.Map(movieUpdateDTO, movieFromDb);
            _repository.UpdateMovie(movieFromDb);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateMovie(int id, JsonPatchDocument<MovieUpdateDTO> patchDoc)
        {
            var movieFromDb = _repository.GetMovieById(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            var movieUpdateDTO = _mapper.Map<MovieUpdateDTO>(movieFromDb);
            patchDoc.ApplyTo(movieUpdateDTO, ModelState);

            if (!TryValidateModel(movieUpdateDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(movieUpdateDTO, movieFromDb);
            _repository.UpdateMovie(movieFromDb);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movieFromDb = _repository.GetMovieById(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            _repository.DeleteMovie(id);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}