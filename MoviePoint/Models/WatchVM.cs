using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class WatchVM
	{
		public Movie Movie { get; set; }
		public Producer Producer { get; set; }
		public List<ActorToMovie> ATMList { get; set; }
		public List<Actor> ActorList { get; set; }
	}
}