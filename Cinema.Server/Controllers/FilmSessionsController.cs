using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Server.Models;

namespace Cinema.Server.Controllers
{
    public class FilmSessionsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: FilmSessions
        public ActionResult Index()
        {
            return View(db.FilmSessions.ToList());
        }

        // GET: FilmSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmSession filmSession = db.FilmSessions.Find(id);
            if (filmSession == null)
            {
                return HttpNotFound();
            }
            return View(filmSession);
        }

        // GET: FilmSessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmSessions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartTime,SeatsCount")] FilmSession filmSession)
        {
            if (ModelState.IsValid)
            {
                db.FilmSessions.Add(filmSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmSession);
        }

        // GET: FilmSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmSession filmSession = db.FilmSessions.Find(id);
            if (filmSession == null)
            {
                return HttpNotFound();
            }
            return View(filmSession);
        }

        // POST: FilmSessions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,SeatsCount")] FilmSession filmSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmSession);
        }

        // GET: FilmSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmSession filmSession = db.FilmSessions.Find(id);
            if (filmSession == null)
            {
                return HttpNotFound();
            }
            return View(filmSession);
        }

        // POST: FilmSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmSession filmSession = db.FilmSessions.Find(id);
            db.FilmSessions.Remove(filmSession);
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
