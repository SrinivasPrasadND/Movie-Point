using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class HomeVM
	{
		public List<Movie> Movies { get; set; }
		public List<Actor> Actors { get; set; }
		public List<Producer> Producers { get; set; }
	}
}