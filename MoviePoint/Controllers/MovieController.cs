using MoviePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePoint.Controllers
{
	public class MovieController : Controller
	{
		private MovieDbContext db = new MovieDbContext();
		// GET: Movie
		public ActionResult Index()
		{
			return View(db.Movies.ToList());
		}

		public ActionResult Create()
		{
			var movieVM = new MovieVM();
			movieVM.Actors = db.Actors.ToList();
			movieVM.Producers = db.Producers.ToList();
			return View(movieVM);
		}

		[HttpPost]
		public ActionResult Create(MovieVM movieVM)
		{
			var movie = new Movie();

			movie.Name = movieVM.Name;
			movie.YearOfRelease = movieVM.YearOfRelease;
			movie.ProducerId = movieVM.ProducerId;
			movie.ImageUrl = movieVM.ImageUrl;
			movie.Language = movieVM.Language;
			movie.Description = movieVM.Description;
			movie.MovieUrl = movieVM.MovieUrl;
			db.Movies.Add(movie);
			db.SaveChanges();

			AddDetailToDb(movieVM.ActorsIds, movie.MovieId);

			return RedirectToAction("Index");
		}


		public ActionResult Update(int id)
		{
			var element = db.Movies.Find(id);
			var movieUpdatemodel = new MovieVM();

			movieUpdatemodel.MovieId = element.MovieId;
			movieUpdatemodel.Name = element.Name;
			movieUpdatemodel.YearOfRelease = element.YearOfRelease;
			movieUpdatemodel.ProducerId = element.ProducerId;
			movieUpdatemodel.ImageUrl = element.ImageUrl;
			movieUpdatemodel.Language = element.Language;
			movieUpdatemodel.Description = element.Description;
			movieUpdatemodel.MovieUrl = element.MovieUrl;

			movieUpdatemodel.Actors = db.Actors.ToList();
			movieUpdatemodel.Producers = db.Producers.ToList();
			return View(movieUpdatemodel);
		}

		[HttpPost]
		public ActionResult Update(MovieVM movieVM)
		{
			var movie = new Movie();

			movie.MovieId = movieVM.MovieId;
			movie.Name = movieVM.Name;
			movie.YearOfRelease = movieVM.YearOfRelease;
			movie.ProducerId = movieVM.ProducerId;
			movie.ImageUrl = movieVM.ImageUrl;
			movie.Language = movieVM.Language;
			movie.Description = movieVM.Description;
			movie.MovieUrl = movieVM.MovieUrl;

			db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();


			try
			{
				if (!movieVM.ActorsIds.Equals(null))
				{
					RemoveDetails(movieVM.MovieId);
					AddDetailToDb(movieVM.ActorsIds, movieVM.MovieId);

				}
			}
			catch (Exception e) {
				Console.WriteLine(e.ToString());
			}


			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			RemoveDetails(id);
			db.Entry(db.Movies.Find(id)).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public void AddDetailToDb(List<int> ids, int movieID)
		{
			foreach (var id in ids)
			{
				var actorToMovie = new ActorToMovie();

				actorToMovie.ActorId = id;
				actorToMovie.MovieId = movieID;

				db.ActorToMovies.Add(actorToMovie);
				db.SaveChanges();
			}

		}
		public void RemoveDetails(int id)
		{
			var DeleteList = db.ActorToMovies.Where(x => x.MovieId.Equals(id)).ToList();

			foreach (var item in DeleteList)
			{
				db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}
	}
}