using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacturaDouglas.Models;

namespace FacturaDouglas.Controllers
{
    public class DatosFacturas1Controller : Controller
    {
        private Entities2 db = new Entities2();

        // GET: DatosFacturas1
        public ActionResult Index()
        {
            return View(db.DatosFactura.ToList());
        }

        // GET: DatosFacturas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosFactura datosFactura = db.DatosFactura.Find(id);
            if (datosFactura == null)
            {
                return HttpNotFound();
            }
            return View(datosFactura);
        }

        // GET: DatosFacturas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosFacturas1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_factura,fecha_factura,id_cliente,descripcion")] DatosFactura datosFactura)
        {
            if (ModelState.IsValid)
            {
                db.DatosFactura.Add(datosFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datosFactura);
        }

        // GET: DatosFacturas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosFactura datosFactura = db.DatosFactura.Find(id);
            if (datosFactura == null)
            {
                return HttpNotFound();
            }
            return View(datosFactura);
        }

        // POST: DatosFacturas1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_factura,fecha_factura,id_cliente,descripcion")] DatosFactura datosFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datosFactura);
        }

        // GET: DatosFacturas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosFactura datosFactura = db.DatosFactura.Find(id);
            if (datosFactura == null)
            {
                return HttpNotFound();
            }
            return View(datosFactura);
        }

        // POST: DatosFacturas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosFactura datosFactura = db.DatosFactura.Find(id);
            db.DatosFactura.Remove(datosFactura);
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
