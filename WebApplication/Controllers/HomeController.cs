using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Controllers
{
        public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var amigos = new List<AmigoEntity>();
            using (var contexto = new myDbContexto())
            {
                amigos = contexto.Amigo.ToList();
            }
            return View(amigos);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AmigoEntity amigo)
        {
            using (var contexto = new myDbContexto())
            {
                contexto.Amigo.Add(amigo);
                contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var amigo = new AmigoEntity();
            using (var contexto = new myDbContexto())
            {
                amigo = contexto.Amigo.FirstOrDefault(a => a.IdAmigo == id);
            }
            return View(amigo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AmigoEntity amigo)
        {
            using (var contexto = new myDbContexto())
            {
                contexto.Entry(amigo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (var contexto = new myDbContexto())
            {
                var amigo = contexto.Amigo.Find(id);
                contexto.Entry(amigo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
