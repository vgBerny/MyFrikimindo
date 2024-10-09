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
    public class LibrosTablesController : Controller
    {
        private FrikimundoDBEntities4 db = new FrikimundoDBEntities4();

        // GET: LibrosTables
        public ActionResult Index()
        {
            return View(db.LibrosTable.ToList());
        }

        // GET: LibrosTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosTable librosTable = db.LibrosTable.Find(id);
            if (librosTable == null)
            {
                return HttpNotFound();
            }
            return View(librosTable);
        }

        // GET: LibrosTables/Create
        public ActionResult Create()
        {
            var librosTable = new LibrosTable
            {
                Fecha = DateTime.Now
            };
            return View(librosTable);
        }

        // POST: LibrosTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Autor,Genero,Saga_literaria,Fecha")] LibrosTable librosTable)
        {
            if (ModelState.IsValid)
            {
                db.LibrosTable.Add(librosTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(librosTable);
        }

        // GET: LibrosTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosTable librosTable = db.LibrosTable.Find(id);
            if (librosTable == null)
            {
                return HttpNotFound();
            }
            return View(librosTable);
        }

        // POST: LibrosTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Autor,Genero,Saga_literaria,Fecha")] LibrosTable librosTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(librosTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(librosTable);
        }

        // GET: LibrosTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosTable librosTable = db.LibrosTable.Find(id);
            if (librosTable == null)
            {
                return HttpNotFound();
            }
            return View(librosTable);
        }

        // POST: LibrosTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibrosTable librosTable = db.LibrosTable.Find(id);
            db.LibrosTable.Remove(librosTable);
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
