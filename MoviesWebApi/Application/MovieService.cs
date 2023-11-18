using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }

        public void AddActorToMovie(int MovieID, int ActorID)
        {
            var movie = _movieRepository.GetMovieByID(MovieID);
            var actor = _actorRepository.GetActorByID(ActorID);

            if (movie != null && actor != null)
            {
                var movieActor = new MovieActors
                {
                    MovieID = movie.MovieID,
                    ActorID = actor.ActorID
                };

                _movieRepository.AddActorToMovie(movieActor);
            }
        }

        public IEnumerable<MovieActors>? GetActorsByMovie(int id)
        {
            return _movieRepository.GetMovieActors(id);
        }
    }

}
