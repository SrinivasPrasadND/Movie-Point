using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePoint.Models
{
	public class Producer
	{
		public int ProducerId { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public int Age { get; set; }
		public string ImageUrl { get; set; }

		public virtual List<Movie> Movie { get; set; }
	}

	public class ProducerVM
	{
		public List<Producer> TopProducers { get; set; }
		public List<Producer> AllProducers { get; set; }
	}

	public class ProducerDetails
	{
		public Producer	Producer { get; set; }
		public List<Movie> Movies { get; set; }

	}
}