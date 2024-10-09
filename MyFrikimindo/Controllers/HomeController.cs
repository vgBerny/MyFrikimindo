using MyFrikimindo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFrikimindo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var modelos = new List<SeriesTable>
            {
                new SeriesTable { Id = 1, Titulo = "Ejemplo1", Fecha = DateTime.Now }
            };

            return View(modelos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}