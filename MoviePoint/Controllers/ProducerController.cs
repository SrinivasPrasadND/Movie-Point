using MoviePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePoint.Controllers
{
    public class ProducerController : Controller
    {
		private MovieDbContext db = new MovieDbContext(); 
        // GET: Producer
        public ActionResult Index()
        {
            return View(db.Producers.ToList());
        }

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Producer producer)
		{
			db.Producers.Add(producer);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Update(int id)
		{
			return View(db.Producers.Find(id));
		}

		[HttpPost]
		public ActionResult Update(Producer producer)
		{
			db.Entry(producer).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			db.Entry(db.Producers.Find(id)).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddProducer()
		{
			return PartialView();
		}

		[HttpPost]
		public ActionResult AddProducer(Producer producer)
		{
			db.Producers.Add(producer);
			db.SaveChanges();
			return RedirectToAction("ProducerDropDown");
		}

		public ActionResult ProducerDropDown()
		{
			return PartialView(db.Producers.ToList());
		}
	}
}