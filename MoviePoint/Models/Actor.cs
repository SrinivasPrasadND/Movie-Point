using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class Actor
	{
		public int ActorId { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public int Age { get; set; }
		public string ImageUrl { get; set; }

		public virtual List<ActorToMovie> ActorToMovie { get; set; }
	}

	public class ActorVM
	{
		public List<Actor> TopActors { get; set; }
		public List<Actor> AllActors { get; set; }
	}

	public class ActorDetails
	{
		public Actor Actor { get; set; }
		public List<Movie> Movies { get; set; }

	}
}