using System;
using System.Web.Mvc;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Web.Controllers
{
    [RoutePrefix("Home")] 
    public class HomeController : Controller
    {
        public ISySTarjetasService SysTarjetasService { get; set; }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var exists = SysTarjetasService.ExisteCupon(1, new DateTime(2015, 08, 18), 1, 8888);

            return View();
        }

        //
        // GET: /Home/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
