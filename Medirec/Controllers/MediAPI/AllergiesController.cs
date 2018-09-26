using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;

namespace Medirec.Controllers.MediAPI
{
    public class AllergiesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Allergies
        public IQueryable<Allergies> GetAllergies()
        {
            return _context.Allergies;
        }

        [EnableQuery(PageSize = 4)]
        [ResponseType(typeof(Allergies))]
        public IHttpActionResult GetAllergies(int id)
        {
            var allergies = _context.Allergies.Where(a => a.UserId == id);
            if (allergies == null)
            {
                return NotFound();
            }

            return Ok(allergies);
        }

        [Route("api/GetAllergiesDetails/{userId}")]
        [ResponseType(typeof(Allergies))]
        public IHttpActionResult GetAllergiesDetails(int userId)
        {
            var allergies = _context.Allergies.Where(a => a.UserId == userId);
            if (allergies == null)
                return NotFound();

            return Ok(allergies);
        }

        [Route("api/GetAllergiesCount/{userId}")]
        [ResponseType(typeof(Allergies))]
        public IHttpActionResult GetAllergiesCount(int userId)
        {
            var allergies = _context.Allergies.Count(i => i.UserId == userId);

            if (allergies == 0)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            return Ok(allergies);
        }

        // PUT: api/Allergies/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutAllergies(int id, AllergiesDto allergiesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var allergies = _context.Allergies.SingleOrDefault(a => a.AllergiesId == id);

            if (allergies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(allergiesDto, allergies);

            _context.SaveChanges();
        }

        // POST: api/Allergies
        [ResponseType(typeof(Allergies))]
        public IHttpActionResult PostAllergies(Allergies allergies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Allergies.Add(allergies);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = allergies.UserId }, allergies);
        }

        // DELETE: api/Allergies/5
        [ResponseType(typeof(Allergies))]
        public IHttpActionResult DeleteAllergies(int id)
        {
            Allergies allergies = _context.Allergies.SingleOrDefault(a => a.AllergiesId == id);

            if (allergies == null)
            {
                return NotFound();
            }

            _context.Allergies.Remove(allergies);
            _context.SaveChanges();

            return Ok(allergies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllergiesExists(int id)
        {
            return _context.Allergies.Count(e => e.AllergiesId == id) > 0;
        }
    }
}