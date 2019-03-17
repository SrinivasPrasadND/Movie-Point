using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class Movie
	{
		public int MovieId { get; set; }
		public string Name { get; set; }
		public string YearOfRelease { get; set; }
		public int ProducerId { get; set; }
		public string ImageUrl { get; set; }
		public string MovieUrl { get; set; }
		public string Language { get; set; }
		public string Description { get; set; }


		public virtual List<ActorToMovie> ActorToMovie { get; set; }
	}
}