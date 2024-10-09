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
    public class PeliculasTablesController : Controller
    {
        private FrikimundoDBEntities1 db = new FrikimundoDBEntities1();

        // GET: PeliculasTables
        public ActionResult Index()
        {
            return View(db.PeliculasTable.ToList());
        }

        // GET: PeliculasTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculasTable peliculasTable = db.PeliculasTable.Find(id);
            if (peliculasTable == null)
            {
                return HttpNotFound();
            }
            return View(peliculasTable);
        }

        // GET: PeliculasTables/Create
        public ActionResult Create()
        {
            var peliculasTable = new PeliculasTable
            {
                Fecha = DateTime.Now
            };
            return View(peliculasTable);
        }

        // POST: PeliculasTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Director,Genero,Fecha")] PeliculasTable peliculasTable)
        {
            if (ModelState.IsValid)
            {
                db.PeliculasTable.Add(peliculasTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peliculasTable);
        }

        // GET: PeliculasTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculasTable peliculasTable = db.PeliculasTable.Find(id);
            if (peliculasTable == null)
            {
                return HttpNotFound();
            }
            return View(peliculasTable);
        }

        // POST: PeliculasTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Director,Genero,Fecha")] PeliculasTable peliculasTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peliculasTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peliculasTable);
        }

        // GET: PeliculasTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculasTable peliculasTable = db.PeliculasTable.Find(id);
            if (peliculasTable == null)
            {
                return HttpNotFound();
            }
            return View(peliculasTable);
        }

        // POST: PeliculasTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeliculasTable peliculasTable = db.PeliculasTable.Find(id);
            db.PeliculasTable.Remove(peliculasTable);
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
