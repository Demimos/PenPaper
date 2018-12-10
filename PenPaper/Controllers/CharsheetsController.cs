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
using PenPaper.Models;

namespace PenPaper.Controllers
{
    public class CharsheetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Charsheets
        public IQueryable<Charsheet> GetCharsheets()
        {
            return db.Charsheets;
        }

        // GET: api/Charsheets/5
        [ResponseType(typeof(Charsheet))]
        public IHttpActionResult GetCharsheet(int id)
        {
            Charsheet charsheet = db.Charsheets.Find(id);
            if (charsheet == null)
            {
                return NotFound();
            }

            return Ok(charsheet);
        }

        // PUT: api/Charsheets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharsheet(int id, Charsheet charsheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charsheet.Id)
            {
                return BadRequest();
            }

            db.Entry(charsheet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharsheetExists(id))
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

        // POST: api/Charsheets
        [ResponseType(typeof(Charsheet))]
        public IHttpActionResult PostCharsheet(Charsheet charsheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Charsheets.Add(charsheet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = charsheet.Id }, charsheet);
        }

        // DELETE: api/Charsheets/5
        [ResponseType(typeof(Charsheet))]
        public IHttpActionResult DeleteCharsheet(int id)
        {
            Charsheet charsheet = db.Charsheets.Find(id);
            if (charsheet == null)
            {
                return NotFound();
            }

            db.Charsheets.Remove(charsheet);
            db.SaveChanges();

            return Ok(charsheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharsheetExists(int id)
        {
            return db.Charsheets.Count(e => e.Id == id) > 0;
        }
    }
}