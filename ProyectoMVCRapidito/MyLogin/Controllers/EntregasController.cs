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
    public class EntregasController : Controller
    {
        private DatabaseMyLoginEntities1 db = new DatabaseMyLoginEntities1();

        // GET: Entregas
        public ActionResult Index()
        {
            var entrega = db.Entrega.Include(e => e.Cliente1).Include(e => e.Destino).Include(e => e.Origen).Include(e => e.Pago1);
            return View(entrega.ToList());
        }

        // GET: Entregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // GET: Entregas/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.Cliente, "clienteID", "Nombre");
            ViewBag.UbicacionDestino = new SelectList(db.Destino, "Id", "Nombre");
            ViewBag.UbicacionOrigen = new SelectList(db.Origen, "Id", "Nombre");
            ViewBag.Pago = new SelectList(db.Pago, "Id", "Nombre");
            return View();
        }

        // POST: Entregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DireccionOrigen,UbicacionOrigen,Producto,Descripcion,Peso,DireccionDestino,UbicacionDestino,Cliente,Pago")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entrega.Add(entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Cliente, "clienteID", "Nombre", entrega.Cliente);
            ViewBag.UbicacionDestino = new SelectList(db.Destino, "Id", "Nombre", entrega.UbicacionDestino);
            ViewBag.UbicacionOrigen = new SelectList(db.Origen, "Id", "Nombre", entrega.UbicacionOrigen);
            ViewBag.Pago = new SelectList(db.Pago, "Id", "Nombre", entrega.Pago);
            return View(entrega);
        }

        // GET: Entregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "clienteID", "Nombre", entrega.Cliente);
            ViewBag.UbicacionDestino = new SelectList(db.Destino, "Id", "Nombre", entrega.UbicacionDestino);
            ViewBag.UbicacionOrigen = new SelectList(db.Origen, "Id", "Nombre", entrega.UbicacionOrigen);
            ViewBag.Pago = new SelectList(db.Pago, "Id", "Nombre", entrega.Pago);
            return View(entrega);
        }

        // POST: Entregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DireccionOrigen,UbicacionOrigen,Producto,Descripcion,Peso,DireccionDestino,UbicacionDestino,Cliente,Pago")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "clienteID", "Nombre", entrega.Cliente);
            ViewBag.UbicacionDestino = new SelectList(db.Destino, "Id", "Nombre", entrega.UbicacionDestino);
            ViewBag.UbicacionOrigen = new SelectList(db.Origen, "Id", "Nombre", entrega.UbicacionOrigen);
            ViewBag.Pago = new SelectList(db.Pago, "Id", "Nombre", entrega.Pago);
            return View(entrega);
        }

        // GET: Entregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // POST: Entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entrega.Find(id);
            db.Entrega.Remove(entrega);
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
