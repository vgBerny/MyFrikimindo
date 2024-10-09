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
    public class SeriesTablesController : Controller
    {
        private FrikimundoDBEntities2 db = new FrikimundoDBEntities2();

        // GET: SeriesTables
        public ActionResult Index()
        {
            return View(db.SeriesTable.ToList());
        }

        // GET: SeriesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeriesTable seriesTable = db.SeriesTable.Find(id);
            if (seriesTable == null)
            {
                return HttpNotFound();
            }
            return View(seriesTable);
        }

        // GET: SeriesTables/Create
        public ActionResult Create() 
        {
            var seriesTable = new SeriesTable 
            {
                Fecha = DateTime.Now
            };
            return View(seriesTable);
        }
            
        

        // POST: SeriesTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Genero,Temporasas,Capitulos,Fecha")] SeriesTable seriesTable)
        {
            if (ModelState.IsValid)
            {
                db.SeriesTable.Add(seriesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seriesTable);
        }

        // GET: SeriesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeriesTable seriesTable = db.SeriesTable.Find(id);
            if (seriesTable == null)
            {
                return HttpNotFound();
            }
            return View(seriesTable);
        }

        // POST: SeriesTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Genero,Temporasas,Capitulos,Fecha")] SeriesTable seriesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seriesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seriesTable);
        }

        // GET: SeriesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeriesTable seriesTable = db.SeriesTable.Find(id);
            if (seriesTable == null)
            {
                return HttpNotFound();
            }
            return View(seriesTable);
        }

        // POST: SeriesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeriesTable seriesTable = db.SeriesTable.Find(id);
            db.SeriesTable.Remove(seriesTable);
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
