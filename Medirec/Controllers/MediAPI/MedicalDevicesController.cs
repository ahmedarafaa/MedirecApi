using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class MedicalDevicesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/MedicalDevices
        public IQueryable<MedicalDevices> GetMedicalDevices()
        {
            return _context.MedicalDevices;
        }

        // GET: api/MedicalDevices/5
        [EnableQuery(PageSize = 4)]
        [ResponseType(typeof(MedicalDevices))]
        public IHttpActionResult GetMedicalDevices(int id)
        {
            var medicalDevices = _context.MedicalDevices.Where(m => m.UserId == id);

            if (medicalDevices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medicalDevices);
        }

        [Route("api/GetMedicalDevicesDetails/{userId}")]
        [ResponseType(typeof(MedicalDevices))]
        public IHttpActionResult GetMedicalDevicesDetails(int userId)
        {
            var medicalDevices = _context.MedicalDevices.Where(m => m.UserId == userId);

            if (medicalDevices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medicalDevices);
        }

        [Route("api/GetMedicalDevicesCount/{userId}")]
        [ResponseType(typeof(MedicalDevices))]
        public IHttpActionResult GetMedicalDevicesCount(int userId)
        {
            var medicalDevices = _context.MedicalDevices.Count(i => i.UserId == userId);

            if (medicalDevices == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medicalDevices);
        }

        // PUT: api/MedicalDevices/5
        [ResponseType(typeof(void))]
        public void PutMedicalDevices(int id, MedicalDevicesDto medicalDevicesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var medicaldevices = _context.MedicalDevices.SingleOrDefault(m => m.MedicalDevicesId == id);

            if (medicaldevices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(medicalDevicesDto, medicaldevices);

            _context.SaveChanges();
        }

        // POST: api/MedicalDevices
        [ResponseType(typeof(MedicalDevices))]
        public IHttpActionResult PostMedicalDevices(MedicalDevices medicalDevices)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.MedicalDevices.Add(medicalDevices);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicalDevices.MedicalDevicesId }, medicalDevices);
        }

        // DELETE: api/MedicalDevices/5
        [ResponseType(typeof(MedicalDevices))]
        public IHttpActionResult DeleteMedicalDevices(int id)
        {
            MedicalDevices medicalDevices = _context.MedicalDevices.SingleOrDefault(m => m.MedicalDevicesId == id);
            if (medicalDevices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.MedicalDevices.Remove(medicalDevices);
            _context.SaveChanges();

            return Ok(medicalDevices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool MedicalDevicesExists(int id)
        {
            return _context.MedicalDevices.Count(e => e.MedicalDevicesId == id) > 0;
        }
    }
}