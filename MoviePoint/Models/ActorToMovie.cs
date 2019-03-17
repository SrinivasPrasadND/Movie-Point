using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class ActorToMovie
	{
		public int ActorToMovieId { get; set; }

		
		public int MovieId { get; set; }
		
		public int ActorId { get; set; }

	}
}