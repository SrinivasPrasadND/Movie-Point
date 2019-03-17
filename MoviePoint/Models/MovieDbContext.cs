using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class MovieDbContext : DbContext
	{
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Producer> Producers { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<ActorToMovie> ActorToMovies { get; set; }
	}
}