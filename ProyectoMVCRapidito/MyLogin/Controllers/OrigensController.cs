using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLogin;

namespace MyLogin.Controllers
{
    public class OrigensController : Controller
    {
        private DatabaseMyLoginEntities1 db = new DatabaseMyLoginEntities1();

        // GET: Origens
        public ActionResult Index()
        {
            return View(db.Origen.ToList());
        }

        // GET: Origens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origen origen = db.Origen.Find(id);
            if (origen == null)
            {
                return HttpNotFound();
            }
            return View(origen);
        }

        // GET: Origens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Origens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Origen origen)
        {
            if (ModelState.IsValid)
            {
                db.Origen.Add(origen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(origen);
        }

        // GET: Origens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origen origen = db.Origen.Find(id);
            if (origen == null)
            {
                return HttpNotFound();
            }
            return View(origen);
        }

        // POST: Origens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Origen origen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(origen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(origen);
        }

        // GET: Origens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origen origen = db.Origen.Find(id);
            if (origen == null)
            {
                return HttpNotFound();
            }
            return View(origen);
        }

        // POST: Origens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Origen origen = db.Origen.Find(id);
            db.Origen.Remove(origen);
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
