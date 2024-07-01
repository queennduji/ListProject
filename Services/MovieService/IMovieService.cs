using System;
using ListProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListProject.Services.MovieService
{
    public interface IMovieService
    {

		Task<List<Movie>> GetAllMovies();

        Task<Movie> GetMovie(int id);

        Task<bool> AddMovie([FromBody] Movie movie);

        Task<bool> UpdateMovie([FromBody] Movie updatedMovie);

        Task<bool> DeleteMovie(int id);

    }

}

