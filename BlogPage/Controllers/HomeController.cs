using BlogPage.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPage.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        // GET: Home
        public ActionResult Index()
        {
            var model = db.Labours.ToList();
            return View(model);
        }
        [Route("Index")]
        [HttpGet]
        public ActionResult Crud()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Crud(Labour list)
        {
            if (list.ID == 0) //for insert
            {
                db.Labours.Add(list);
            }
            else
            {
                var updateData = db.Labours.Find(list.ID);
                if (updateData == null)
                {
                    return HttpNotFound();
                }
                updateData.Job = list.Job;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var model = db.Labours.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Index", model);
        }

        public ActionResult Delete(int id)
        {
            var delete = db.Labours.Find(id);
            if (delete == null)
            {
                return HttpNotFound();
            }
            db.Labours.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}