using MoviePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePoint.Controllers
{
    public class ActorController : Controller
    {
		private MovieDbContext db = new MovieDbContext();
        // GET: Actor
        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Actor actor)
		{
			db.Actors.Add(actor);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Update(int id)
		{
			return View(db.Actors.Find(id));
		}

		[HttpPost]
		public ActionResult Update(Actor actor)
		{
			db.Entry(actor).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			var actor = db.Actors.Find(id);
			db.Entry(actor).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AddActor()
		{
			return PartialView();
		}

		[HttpPost]
		public ActionResult AddActor(Actor actor)
		{
			db.Actors.Add(actor);
			db.SaveChanges();
			return RedirectToAction("ActorDropDown");
		}

		public ActionResult ActorDropDown()
		{
			return PartialView(db.Actors.ToList());
		}
	}
}