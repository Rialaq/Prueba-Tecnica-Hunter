using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IActorRepository
    {
        /// <summary>
        /// Obtener todos los actores
        /// </summary>
        /// <returns> ICollection<Actor> con todos los actores. </returns>
        IEnumerable<Actor>? GetActors();

        /// <summary>
        /// Obtener un actor por ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> <Actor> con el actor perteneciente al ID. </returns>
        Actor? GetActorByID(int id);

        /// <summary>
        /// Obtener actores por nombre usando Like%.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> ICollection<Actor> con los acatores que pertenecen al completivo del nombre. </returns>
        IEnumerable<Actor>? GetActorByName(string name);

        /// <summary>
        /// Recibe el <actor> para posteriormente insertarlo a la base de datos.
        /// </summary>
        /// <param name="actor"></param>
        void CreateActor(Actor actor);

        /// <summary>
        /// Recibe el <actor> para posteriormente actualizalo en la base de datos.
        /// </summary>
        /// <param name="actor"></param>
        void UpdateActor(Actor actorToUpdate, Actor actor);

        /// <summary>
        /// Recibe el Id del actor para posteriormente eliminarlo de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        void DeleteActor(Actor actor);
    }
}
