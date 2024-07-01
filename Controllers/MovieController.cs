using System;
using ListProject.Data;
using ListProject.Models;
using ListProject.Services.MovieService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var result = await _movieService.GetAllMovies();

            if (result is null)
                return NotFound("There are no movies available");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var result = await _movieService.GetMovie(id);

            if (result is null)
                return NotFound("Movie not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie([FromBody] Movie movie)
        {
            var result = await _movieService.AddMovie(movie);

            if (result is false)
                return NotFound("Movie not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie([FromBody] Movie updatedMovie)
        {
            var result = await _movieService.UpdateMovie(updatedMovie);

            if (result is false)
                return NotFound("Movie not found");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
        {

            var result = await _movieService.DeleteMovie(id);

            if (result is false)
                return NotFound("Movie not found");

            return Ok(result);
        }
    }
}

