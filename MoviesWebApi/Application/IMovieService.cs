using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IMovieService
    {
        public void AddActorToMovie(int MovieID, int ActorID);
        public IEnumerable<MovieActors>? GetActorsByMovie(int MovieId);
    }
}
