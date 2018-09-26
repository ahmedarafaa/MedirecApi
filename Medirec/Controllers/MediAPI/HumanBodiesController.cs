using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class HumanBodiesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/HumanBodies
        public IQueryable<HumanBody> GetHumanBody()
        {
            return _context.HumanBody;
        }

        // GET: api/HumanBodies/5
        [ResponseType(typeof(HumanBody))]
        public IHttpActionResult GetHumanBody(int id)
        {
            var humanBody = _context.HumanBody.OrderByDescending(o => o.Date).FirstOrDefault(h => h.UserId == id);
            if (humanBody == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(humanBody);
        }

        [Route("api/GetHumanBodyDetails/{userId}")]
        [ResponseType(typeof(HumanBody))]
        public IHttpActionResult GetHumanBodyDetails(int userId)
        {
            var humanBody = _context.HumanBody.Where(m => m.UserId == userId);

            if (humanBody == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(humanBody);
        }

        [Route("api/GetHumanBodyCount/{userId}")]
        [ResponseType(typeof(HumanBody))]
        public IHttpActionResult GetHumanBodyCount(int userId)
        {
            var humanBody = _context.HumanBody.Count(i => i.UserId == userId);

            if (humanBody == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(humanBody);
        }

        // PUT: api/HumanBodies/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutHumanBody(int id, HumanBodyDto humanBodyDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var humanBody = _context.HumanBody.SingleOrDefault(h => h.HumanBodyId == id);

            if (humanBody == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(humanBodyDto, humanBody);

            _context.SaveChanges();
        }

        // POST: api/HumanBodies
        [ResponseType(typeof(HumanBody))]
        public IHttpActionResult PostHumanBody(HumanBody humanBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HumanBody.Add(humanBody);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = humanBody.HumanBodyId }, humanBody);
        }

        // DELETE: api/HumanBodies/5
        [ResponseType(typeof(HumanBody))]
        public IHttpActionResult DeleteHumanBody(int id)
        {
            HumanBody humanBody = _context.HumanBody.SingleOrDefault(h => h.HumanBodyId == id);
            if (humanBody == null)
            {
                return NotFound();
            }

            _context.HumanBody.Remove(humanBody);
            _context.SaveChanges();

            return Ok(humanBody);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HumanBodyExists(int id)
        {
            return _context.HumanBody.Count(e => e.HumanBodyId == id) > 0;
        }
    }
}