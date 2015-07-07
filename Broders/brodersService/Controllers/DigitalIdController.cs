using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using brodersService;
using brodersService.Models;

namespace brodersService.Controllers
{
    [AllowAnonymous]
    public class DigitalIdController : ApiController
    {
        private brodersContext db = new brodersContext();

        // GET: api/DigitalId
        public IQueryable<DigitalIds> GetDigitalIds()
        {
            return db.DigitalIds;
        }

        // GET: api/DigitalId/5
        [ResponseType(typeof(DigitalIds))]
        public IHttpActionResult GetDigitalIds(int id)
        {
            DigitalIds digitalIds = db.DigitalIds.Find(id);
            if (digitalIds == null)
            {
                return NotFound();
            }

            return Ok(digitalIds);
        }

        // PUT: api/DigitalId/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDigitalIds(int id, DigitalIds digitalIds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != digitalIds.ID)
            {
                return BadRequest();
            }

            db.Entry(digitalIds).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DigitalIdsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DigitalId
        [ResponseType(typeof(DigitalIds))]
        public IHttpActionResult PostDigitalIds(DigitalIds digitalIds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DigitalIds.Add(digitalIds);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = digitalIds.ID }, digitalIds);
        }

        // DELETE: api/DigitalId/5
        [ResponseType(typeof(DigitalIds))]
        public IHttpActionResult DeleteDigitalIds(int id)
        {
            DigitalIds digitalIds = db.DigitalIds.Find(id);
            if (digitalIds == null)
            {
                return NotFound();
            }

            db.DigitalIds.Remove(digitalIds);
            db.SaveChanges();

            return Ok(digitalIds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DigitalIdsExists(int id)
        {
            return db.DigitalIds.Count(e => e.ID == id) > 0;
        }
    }
}