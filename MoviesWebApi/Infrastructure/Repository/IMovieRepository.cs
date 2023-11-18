using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieRepository
    {
        /// <summary>
        /// Obtiene todas las peliculas de la base de datos.
        /// </summary>
        /// <returns> IEnumerable<Movie> con todas las peliculas.  </returns>
        IEnumerable<Movie>? GetMovies();

        /// <summary>
        /// Obtiene una pelicula a la que pertenece el ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> IEnumerable<Movie> con la pelicula correspondiente al ID </returns>
        Movie? GetMovieByID(int id);

        /// <summary>
        /// Obtiene las peliculas por Titulo completivo por sugerencia.
        /// </summary>
        /// <param name="title"></param>
        /// <returns> IEnumerable<Movie> con las peliculas correspondientes. </returns>
        IEnumerable<Movie>? GetMovieByTitle(string title);

        IEnumerable<MovieActors>? GetMovieActors(int MovieID);

        /// <summary>
        /// Inserta una pelicula en la base de datos uando los datos recibidos.
        /// </summary>
        /// <param name="movie"></param>
        void CreateMovie(Movie movie);

        /// <summary>
        /// Actualiza una pelicula especifica en la base de datos usando los datos recibidos.
        /// </summary>
        /// <param name="movie"></param>
        void UpdateMovie(Movie movieToUpdate, Movie movie);

        /// <summary>
        /// Borra una pelicula especifica correspondiente al ID indicado.
        /// </summary>
        /// <param name="id"></param>
        void DeleteMovie(Movie movie);

        void AddActorToMovie(MovieActors movie);

    }
}
