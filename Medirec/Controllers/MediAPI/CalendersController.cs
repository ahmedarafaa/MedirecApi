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
    public class CalendersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // GET: api/Calenders/5
        [Route("api/Calenders/{doctorId}/{entityId}")]
        [ResponseType(typeof(Calenders))]
        public IHttpActionResult GetCalenders(int doctorId, int entityId)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var calenders = _context.Calenders.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            if (calenders == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(calenders);
        }

        // PUT: api/Calenders/5
        [ResponseType(typeof(void))]
        public void PutCalenders(int calendersId, CalendersDto calendersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var calender = _context.Calenders.SingleOrDefault(c => c.CalendersId == calendersId);

            if (calender == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(calendersDto, calender);

            _context.SaveChanges();
        }

        // POST: api/Calenders
        [ResponseType(typeof(Calenders))]
        public CalendersDto PostCalenders(CalendersDto calendersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var calender = Mapper.Map<CalendersDto, Calenders>(calendersDto);

            _context.Calenders.Add(calender);
            _context.SaveChanges();

            return calendersDto;
        }

        // DELETE: api/Calenders/5
        [ResponseType(typeof(Calenders))]
        public IHttpActionResult DeleteCalenders(int id)
        {
            Calenders calenders = _context.Calenders.Find(id);
            if (calenders == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Calenders.Remove(calenders);
            _context.SaveChanges();

            return Ok(calenders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool CalendersExists(int id)
        {
            return _context.Calenders.Count(e => e.CalendersId == id) > 0;
        }
    }
}