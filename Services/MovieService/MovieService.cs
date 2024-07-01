using System;
using ListProject.Data;
using ListProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListProject.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            return movies;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie is null)
                return null;

            return movie;
        }

        public async Task<bool> AddMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);

           var result =  await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateMovie([FromBody] Movie updatedMovie)
        {
            var dbMovie = await _context.Movies.FindAsync(updatedMovie.Id);

            if (updatedMovie is null || dbMovie is null)
                return false;

            dbMovie.Name = updatedMovie.Name;
            dbMovie.Genre = updatedMovie.Genre;

           await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie is null)
                return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return true;
        }

       

       
    }
}

