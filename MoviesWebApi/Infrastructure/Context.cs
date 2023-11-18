using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Actor>? Actors { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<MovieActors>? MovieActors { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<MovieActors>()
                .HasKey(ma => new { ma.MovieID, ma.ActorID });
       }
    }
}