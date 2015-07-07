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
using System.Web.Http.Cors;

namespace brodersService.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertyInfoController : ApiController
    {
        private brodersContext db = new brodersContext();

        // GET: api/PropertyInfo
        public IQueryable<PropertyInfo> GetPropertyInfoes()
        {
            return db.PropertyInfoes;
        }

        // GET: api/PropertyInfo/5
        [ResponseType(typeof(PropertyInfo))]
        public IHttpActionResult GetPropertyInfo(int id)
        {
            PropertyInfo propertyInfo = db.PropertyInfoes.Find(id);
            if (propertyInfo == null)
            {
                return NotFound();
            }

            return Ok(propertyInfo);
        }

        // PUT: api/PropertyInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPropertyInfo(int id, PropertyInfo propertyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(propertyInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyInfoExists(id))
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

        // POST: api/PropertyInfo
        [ResponseType(typeof(PropertyInfo))]
        public IHttpActionResult PostPropertyInfo(PropertyInfo propertyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PropertyInfoes.Add(propertyInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = propertyInfo.ID }, propertyInfo);
        }

        // DELETE: api/PropertyInfo/5
        [ResponseType(typeof(PropertyInfo))]
        public IHttpActionResult DeletePropertyInfo(int id)
        {
            PropertyInfo propertyInfo = db.PropertyInfoes.Find(id);
            if (propertyInfo == null)
            {
                return NotFound();
            }

            db.PropertyInfoes.Remove(propertyInfo);
            db.SaveChanges();

            return Ok(propertyInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyInfoExists(int id)
        {
            return db.PropertyInfoes.Count(e => e.ID == id) > 0;
        }
    }
}