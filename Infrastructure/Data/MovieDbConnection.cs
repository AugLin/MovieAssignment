using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieDbConnection:DbContext
    {
        public MovieDbConnection(DbContextOptions<MovieDbConnection> options) : base(options)
        {

        }
        public DbSet<Casts> Casts { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Trailers> Trailers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorites>()
                .HasKey(f => new { f.MovieId, f.UserId });

            modelBuilder.Entity<MovieCasts>()
                .HasKey(MovieCasts => new { MovieCasts.CastId, MovieCasts.Character, MovieCasts.MovieId });

            modelBuilder.Entity<MovieGenres>()
                .HasKey(MovieGenres => new {MovieGenres.GenreId, MovieGenres.MovieId});

            modelBuilder.Entity<Purchases>()
                .HasKey(Purchases => new {Purchases.MovieId, Purchases.UserId});

            modelBuilder.Entity<Reviews>()
                .HasKey(Reviews => new {Reviews.MovieId, Reviews.UserId});

            modelBuilder.Entity<UserRoles>()
                .HasKey(UserRoles => new {UserRoles.RoleId, UserRoles.UserId});

            base.OnModelCreating(modelBuilder);
        }

        internal void GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
