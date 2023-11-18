using Domain.Interfaces;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Context _context;

        public MovieRepository(Context context)
        {
            _context = context;
        }

        public void CreateMovie(Movie movie)
        {
            _context.Movies?.Add(movie);
            _context.SaveChanges();
        }

        public void AddActorToMovie(MovieActors movieActor)
        {
            _context.MovieActors?.Add(movieActor);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies?.Remove(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movieToUpdate, Movie movie)
        {
            if (movieToUpdate != null)
            {
                _context.Entry(movieToUpdate).CurrentValues.SetValues(movie);
                _context.SaveChanges();
            }
        }
        
        public Movie? GetMovieByID(int id)
        {
            return _context.Movies?.Where(m => m.MovieID == id).FirstOrDefault();
        }

        public IEnumerable<Movie>? GetMovieByTitle(string title)
        {
            return _context.Movies?.Where(m => m.Title.StartsWith(title)).ToList();
        }

        public IEnumerable<Movie>? GetMovies()
        {
            return _context.Movies?.ToList();
        }

        public IEnumerable<MovieActors>? GetMovieActors(int MovieID)
        {
            var MovieActors = _context.MovieActors?
                .Where(x => x.MovieID == MovieID)
                .Include(x => x.Movie).Include(x => x.Actor);

            return MovieActors;
        }

    }
}