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
    public class ComicsMangasTablesController : Controller
    {
        private FrikimundoDBEntities5 db = new FrikimundoDBEntities5();

        // GET: ComicsMangasTables
        public ActionResult Index()
        {
            return View(db.ComicsMangasTable.ToList());
        }

        // GET: ComicsMangasTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicsMangasTable comicsMangasTable = db.ComicsMangasTable.Find(id);
            if (comicsMangasTable == null)
            {
                return HttpNotFound();
            }
            return View(comicsMangasTable);
        }

        // GET: ComicsMangasTables/Create
        public ActionResult Create()
        {
            var comicsMangasTable = new ComicsMangasTable
            {
                Fecha = DateTime.Now
            };
            return View(comicsMangasTable);
        }

        // POST: ComicsMangasTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Autor,Genero,Capitulos,Tomos,Fecha")] ComicsMangasTable comicsMangasTable)
        {
            if (ModelState.IsValid)
            {
                db.ComicsMangasTable.Add(comicsMangasTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comicsMangasTable);
        }

        // GET: ComicsMangasTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicsMangasTable comicsMangasTable = db.ComicsMangasTable.Find(id);
            if (comicsMangasTable == null)
            {
                return HttpNotFound();
            }
            return View(comicsMangasTable);
        }

        // POST: ComicsMangasTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Autor,Genero,Capitulos,Tomos,Fecha")] ComicsMangasTable comicsMangasTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comicsMangasTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comicsMangasTable);
        }

        // GET: ComicsMangasTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicsMangasTable comicsMangasTable = db.ComicsMangasTable.Find(id);
            if (comicsMangasTable == null)
            {
                return HttpNotFound();
            }
            return View(comicsMangasTable);
        }

        // POST: ComicsMangasTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComicsMangasTable comicsMangasTable = db.ComicsMangasTable.Find(id);
            db.ComicsMangasTable.Remove(comicsMangasTable);
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
