using MoviePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePoint.Controllers
{
    public class HomeController : Controller
    {
		private MovieDbContext db = new MovieDbContext();
        // GET: Home
        public ActionResult Index()
        {
			var Producers = new List<Producer>();
			var homeVm = new HomeVM();

			homeVm.Actors = db.Actors.Take(3).ToList();
			homeVm.Movies = db.Movies.OrderByDescending(x =>x.MovieId).Take(6).ToList();

			foreach (var item in homeVm.Movies)
			{
				var producer = db.Producers.Find(item.ProducerId);
				Producers.Add(producer);

			}

			homeVm.Producers = Producers;
            return View(homeVm);
        }

		public ActionResult Actors()
		{
			var actorVM = new ActorVM();
			actorVM.TopActors = db.Actors.Take(3).OrderBy(x=>x.ActorId).ToList();
			actorVM.AllActors = db.Actors.OrderBy(x => x.ActorId).Skip(3).ToList();
			return View(actorVM);
		}

		public ActionResult AboutActor(int id)
		{
			var aboutActor = new ActorDetails();
			var movieList = new List<Movie>();
			aboutActor.Actor = db.Actors.Find(id);
			var moviesIds = db.ActorToMovies.Where(x => x.ActorId.Equals(id)).ToList();

			foreach (var mId in moviesIds)
			{
				var movie = db.Movies.Find(mId.MovieId);
				movieList.Add(movie);
			}
			aboutActor.Movies = movieList;
			return View(aboutActor);
		}

		public ActionResult Movies()
		{
			var Producers = new List<Producer>();
			var homeVm = new HomeVM();

		
			homeVm.Movies = db.Movies.Take(9).ToList();

			foreach (var item in homeVm.Movies)
			{
				var producer = db.Producers.Find(item.ProducerId);
				Producers.Add(producer);

			}

			homeVm.Producers = Producers;
			return View(homeVm);
		}

		public ActionResult WatchMovie(int id)
		{
			var watchVm = new WatchVM();
			List<Actor> Actors = new List<Actor>();

			watchVm.Movie = db.Movies.Find(id);
			watchVm.Producer = db.Producers.Find(watchVm.Movie.ProducerId);
			watchVm.ATMList = db.ActorToMovies.Where(x => x.MovieId.Equals(watchVm.Movie.MovieId)).ToList();

			foreach (var atm in watchVm.ATMList)
			{
				var actor = db.Actors.Find(atm.ActorId);
				Actors.Add(actor);

			}

			watchVm.ActorList = Actors;
			return View(watchVm);
		}

		public ActionResult LoadMoreMovies(int count)
		{
			var Producers = new List<Producer>();
			var homeVm = new HomeVM();


			homeVm.Movies = db.Movies.OrderBy(x=>x.MovieId).Skip((count * 9)).Take(9).ToList();

			foreach (var item in homeVm.Movies)
			{
				var producer = db.Producers.Find(item.ProducerId);
				Producers.Add(producer);

			}

			homeVm.Producers = Producers;
			return PartialView(homeVm);
		}

		public ActionResult Producers()
		{
			var producerVM = new ProducerVM();
			producerVM.TopProducers = db.Producers.OrderBy(x => x.ProducerId).Take(3).ToList();
			producerVM.AllProducers = db.Producers.OrderBy(x => x.ProducerId).Skip(3).ToList();
			return View(producerVM);
		}

		public ActionResult AboutProducer(int id)
		{
			var aboutProducer = new ProducerDetails();
			
			aboutProducer.Producer = db.Producers.Find(id);
			aboutProducer.Movies = db.Movies.Where(x => x.ProducerId.Equals(id)).ToList();

			return View(aboutProducer);
		}

		public ActionResult ContactUs()
		{
			return View();
		}
    }
}