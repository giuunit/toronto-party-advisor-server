using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TorontoPartyAdvisor.Commands;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Backend.Utility.Controllers
{
    public class PlacesController : Controller
    {
        private PartyAdvisorEntities db = new PartyAdvisorEntities();

        // GET: Places
        public async Task<ActionResult> Index()
        {
            return View(await db.Places.OrderBy(x=>x.Order).ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Place place)
        {
            if (ModelState.IsValid)
            {
                place.DateCreated = DateTimeOffset.Now;
                place.DateUpdated = DateTimeOffset.Now;

                db.Places.Add(place);
                await db.SaveChangesAsync();

                CacheHelper.RefreshPlaces();

                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Place place)
        {
            if (ModelState.IsValid)
            {
                place.DateUpdated = DateTimeOffset.Now;

                db.Entry(place).State = EntityState.Modified;
                await db.SaveChangesAsync();

                CacheHelper.RefreshPlaces();

                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Place place = await db.Places.FindAsync(id);
            db.Places.Remove(place);
            await db.SaveChangesAsync();

            CacheHelper.RefreshPlaces();

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
