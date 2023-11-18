using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ActorController: Controller
    {
        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository  = actorRepository;
        }

        /// <summary>
        /// Obtiene y retorna todas las peliculas disponibles en la base de datos.
        /// </summary>
        /// <returns> IEnumerable<Movies> </returns>
        [HttpGet("get")]
        public IActionResult GetActors()
        {
            var actors = _actorRepository.GetActors();

            if (actors == null)
            {
                return NoContent();
            }

            return Json(actors);
        }

        /// <summary>
        /// Obtiene y retorna la pelicula(Movie) perteneciente al ID proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Movie </returns>
        [HttpGet("get/{id}")]
        public IActionResult GetActorByID(int id) 
        {
            if (id > 0)
            {
                var actor = _actorRepository.GetActorByID(id);

                if (actor == null)
                {
                    return NotFound($"No found actor with ID: {id}.");
                }

                return Json(actor);
            }

            return BadRequest("The ID to search was not entered, please enter it.");
        }

        /// <summary>
        /// Obtiene y retorna todas las peliculas que conincidan con el titulo.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> IEnumerable<Movies> </returns>
        [HttpGet("get/{name}")]
        public IActionResult GetMoviesByTitle(string name) 
        {
            if(!string.IsNullOrEmpty(name))
            {
                var actors = _actorRepository.GetActorByName(name);

                if(actors == null)
                {
                    return NoContent();
                }

                return Json(actors);
            }

            return BadRequest("The Title to search was not entered, please enter it.");
        }

        /// <summary>
        /// Inserta en una nueva pelicula en la base de datos
        /// </summary>
        /// <param name="actor"></param>
        /// <returns> Ok 200 </returns>
        [HttpPost("create")]
        public IActionResult CreateMovie([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _actorRepository.CreateActor(actor);
            return Ok();
        }
        
        /// <summary>
        /// Actualiza la pelicula perteneciente al ID proporcionado con los datos colocados.
        /// </summary>
        /// <param name="actor"></param>
        /// <returns> Ok 200 </returns>
        [HttpPut("update")]
        public IActionResult UpdateMovie([FromBody] Actor actor)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            
            var actorToUpadate = _actorRepository.GetActorByID(actor.ActorID);
            if(actorToUpadate == null)
            {
                return NoContent();
            }

            _actorRepository.UpdateActor(actorToUpadate, actor);
            return Ok();
        }

        /// <summary>
        /// Elimina la pelicula perteneciente ael ID proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult DeleteMovie(int id) 
        {
            if(id > 0) 
            {
                var actorToDelete = _actorRepository.GetActorByID(id);
                if(actorToDelete == null)
                {
                    return NotFound($"Not found movie with ID: ${id}");
                }

                _actorRepository.DeleteActor(actorToDelete);
                return Ok();
            }

            return BadRequest($"You have not provided an ID, please enter the movie ID.");
        }
    }
}
