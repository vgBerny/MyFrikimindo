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
    public class VideoJuegosTablesController : Controller
    {
        private FrikimundoDBEntities3 db = new FrikimundoDBEntities3();

        // GET: VideoJuegosTables
        public ActionResult Index()
        {
            return View(db.VideoJuegosTable.ToList());
        }

        // GET: VideoJuegosTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosTable videoJuegosTable = db.VideoJuegosTable.Find(id);
            if (videoJuegosTable == null)
            {
                return HttpNotFound();
            }
            return View(videoJuegosTable);
        }

        // GET: VideoJuegosTables/Create
        public ActionResult Create()
        {
            var videoJuegosTable = new VideoJuegosTable
            {
                Fecha = DateTime.Now
            };
            return View(videoJuegosTable);
        }

        // POST: VideoJuegosTables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Plataforma,Genero,Fecha")] VideoJuegosTable videoJuegosTable)
        {
            if (ModelState.IsValid)
            {
                db.VideoJuegosTable.Add(videoJuegosTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoJuegosTable);
        }

        // GET: VideoJuegosTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosTable videoJuegosTable = db.VideoJuegosTable.Find(id);
            if (videoJuegosTable == null)
            {
                return HttpNotFound();
            }
            return View(videoJuegosTable);
        }

        // POST: VideoJuegosTables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Plataforma,Genero,Fecha")] VideoJuegosTable videoJuegosTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoJuegosTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoJuegosTable);
        }

        // GET: VideoJuegosTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosTable videoJuegosTable = db.VideoJuegosTable.Find(id);
            if (videoJuegosTable == null)
            {
                return HttpNotFound();
            }
            return View(videoJuegosTable);
        }

        // POST: VideoJuegosTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoJuegosTable videoJuegosTable = db.VideoJuegosTable.Find(id);
            db.VideoJuegosTable.Remove(videoJuegosTable);
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
