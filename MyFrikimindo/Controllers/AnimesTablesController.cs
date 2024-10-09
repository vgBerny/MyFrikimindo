using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFrikimindo.Models;

namespace MyFrikimindo.Controllers
{
    public class AnimesTablesController : Controller
    {
        private FrikimundoDBEntities7 db = new FrikimundoDBEntities7();

        // GET: AnimesTables
        public ActionResult Index()
        {
            return View(db.AnimesTable.ToList());
        }

        // GET: AnimesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimesTable animesTable = db.AnimesTable.Find(id);
            if (animesTable == null)
            {
                return HttpNotFound();
            }
            return View(animesTable);
        }

        // GET: AnimesTables/Create
        public ActionResult Create()
        {
            var animesTable = new AnimesTable
            {
                Fecha = DateTime.Now
            };
            return View(animesTable);
        }

        // POST: AnimesTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Genero,Capitulos,Temporadas,Fecha")] AnimesTable animesTable)
        {
            if (ModelState.IsValid)
            {
                db.AnimesTable.Add(animesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animesTable);
        }

        // GET: AnimesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimesTable animesTable = db.AnimesTable.Find(id);
            if (animesTable == null)
            {
                return HttpNotFound();
            }
            return View(animesTable);
        }

        // POST: AnimesTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Genero,Capitulos,Temporadas,Fecha")] AnimesTable animesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animesTable);
        }

        // GET: AnimesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimesTable animesTable = db.AnimesTable.Find(id);
            if (animesTable == null)
            {
                return HttpNotFound();
            }
            return View(animesTable);
        }

        // POST: AnimesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimesTable animesTable = db.AnimesTable.Find(id);
            db.AnimesTable.Remove(animesTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
