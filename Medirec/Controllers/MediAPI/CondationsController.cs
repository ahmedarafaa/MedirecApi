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
    public class CondationsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Condations
        public IQueryable<Condations> GetCondations()
        {
            return _context.Condations;
        }

        // GET: api/Condations/5
        [ResponseType(typeof(Condations))]
        [EnableQuery(PageSize = 4)]
        public IHttpActionResult GetCondations(int id)
        {
            var condations = _context.Condations.Where(c => c.UserId == id);
            if (condations == null)
            {
                return NotFound();
            }

            return Ok(condations);
        }

        [Route("api/GetCondationsDetails/{userId}")]
        [ResponseType(typeof(Condations))]
        public IHttpActionResult GetCondationsDetails(int userId)
        {
            var condations = _context.Condations.Where(m => m.UserId == userId);

            if (condations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(condations);
        }

        [Route("api/GetCondationsCount/{userId}")]
        [ResponseType(typeof(Condations))]
        public IHttpActionResult GetCondationsCount(int userId)
        {
            var condations = _context.Condations.Count(i => i.UserId == userId);

            if (condations <= 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(condations);
        }

        // PUT: api/Condations/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutCondations(int id, CondationsDto condationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var condation = _context.Condations.SingleOrDefault(a => a.CondationsId == id);

            if (condation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(condationsDto, condation);

            _context.SaveChanges();
        }

        // POST: api/Condations
        [ResponseType(typeof(Condations))]
        public IHttpActionResult PostCondations(Condations condations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Condations.Add(condations);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condations.CondationsId }, condations);
        }

        // DELETE: api/Condations/5
        [ResponseType(typeof(Condations))]
        public IHttpActionResult DeleteCondations(int id)
        {
            Condations condations = _context.Condations.SingleOrDefault(c => c.CondationsId == id);
            if (condations == null)
            {
                return NotFound();
            }

            _context.Condations.Remove(condations);
            _context.SaveChanges();

            return Ok(condations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondationsExists(int id)
        {
            return _context.Condations.Count(e => e.CondationsId == id) > 0;
        }
    }
}