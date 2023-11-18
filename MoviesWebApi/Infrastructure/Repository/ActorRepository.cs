using Domain.Models;
using Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly Context _context;
        public ActorRepository(Context context)
        {
            _context = context;
        }

        public void CreateActor(Actor actor)
        {
            _context.Actors?.Add(actor);
            _context.SaveChanges();
        }

        public void DeleteActor(Actor actor)
        {
            _context.Actors?.Remove(actor);
            _context.SaveChanges();
        }
        public void UpdateActor(Actor actorToUpdate, Actor actor)
        {
            if (actorToUpdate == null)
            {
                _context.Entry(actorToUpdate).CurrentValues.SetValues(actor);
                _context.SaveChanges();
            }
        }

        public Actor? GetActorByID(int id)
        {
            return _context.Actors?.Where(a => a.ActorID == id).FirstOrDefault();
        }

        public IEnumerable<Actor>? GetActorByName(string name)
        {
            return _context.Actors?.Where(a => a.Fullname.StartsWith(name));
        }

        public IEnumerable<Actor>? GetActors()
        {
            return _context.Actors?.ToList();
        }

    }
}
