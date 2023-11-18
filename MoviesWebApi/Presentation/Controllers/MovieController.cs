using Application;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieService _movieService;

        public MovieController(IMovieRepository movieRepository, IMovieService movieService)
        {
            _movieRepository = movieRepository;
            _movieService = movieService;
        }

        /// <summary>
        /// Obtiene y retorna todas las peliculas disponibles en la base de datos.
        /// </summary>
        /// <returns> IEnumerable<Movies> </returns>
        [HttpGet("get")]
        public IActionResult GetMovies()
        {
            var movies = _movieRepository.GetMovies();

            if (movies == null)
            {
                return NoContent();
            }

            return Json(movies);
        }

        /// <summary>
        /// Obtiene y retorna la pelicula(Movie) perteneciente al ID proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Movie </returns>
        [HttpGet("get/{id}")]
        public IActionResult GetMovieByID(int id) 
        {
            if (id > 0)
            {
                var movieByID = _movieRepository.GetMovieByID(id);

                if (movieByID == null)
                {
                    return NotFound($"No found movie with ID: {id}.");
                }

                return Json(movieByID);
            }

            return BadRequest("The ID to search was not entered, please enter it.");
        }

        /// <summary>
        /// Obtiene y retorna todas las peliculas que conincidan con el titulo.
        /// </summary>
        /// <param name="title"></param>
        /// <returns> IEnumerable<Movies> </returns>
        [HttpGet("get/title/{title}")]
        public IActionResult GetMoviesByTitle(string title) 
        {
            if(!string.IsNullOrEmpty(title))
            {
                var movies = _movieRepository.GetMovieByTitle(title);

                if(movies == null)
                {
                    return NoContent();
                }

                return Json(movies);
            }

            return BadRequest("The Title to search was not entered, please enter it.");
        }

        /// <summary>
        /// Obtiene los actores de las peliculas.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> IEnumerable<MovieActors> </returns>
        [HttpGet("get/actors/{id}")]
        public IActionResult GetMovieActors(int id)
        {
            var MovieActors = _movieService.GetActorsByMovie(id);
            if (MovieActors == null)
            {
                return NoContent();
            }

            return Json(MovieActors);
        }

        /// <summary>
        /// Inserta en una nueva pelicula en la base de datos
        /// </summary>
        /// <param name="movie"></param>
        /// <returns> Ok 200 </returns>
        [HttpPost("create")]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _movieRepository.CreateMovie(movie);
            return Ok();
        }

        /// <summary>
        /// Agrega un actor ya creado a una pelicula ya creada.
        /// </summary>
        /// <param name="MovieID"></param>
        /// <param name="ActorID"></param>
        /// <returns></returns>
        [HttpPost("add/actor")]
        public IActionResult AddActorToMovie(int MovieID, int ActorID)
        {
            _movieService.AddActorToMovie(MovieID, ActorID);
            return Ok();
        }

        /// <summary>
        /// Actualiza la pelicula perteneciente al ID proporcionado con los datos colocados.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns> Ok 200 </returns>
        [HttpPut("update")]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            
            var movieToUpdate = _movieRepository.GetMovieByID(movie.MovieID);
            if(movieToUpdate == null)
            {
                return NoContent();
            }

            _movieRepository.UpdateMovie(movieToUpdate, movie);
            return Ok();
        }

        /// <summary>
        /// Elimina la pelicula perteneciente ael ID proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult DeleteMovie(int MovieID) 
        {
            if(MovieID > 0) 
            {
                var movieToDelete = _movieRepository.GetMovieByID(MovieID);
                if(movieToDelete == null)
                {
                    return NotFound($"Not found movie with ID: ${MovieID}");
                }

                _movieRepository.DeleteMovie(movieToDelete);
                return Ok();
            }

            return BadRequest($"You have not provided an ID, please enter the movie ID.");
        }
    }
}
