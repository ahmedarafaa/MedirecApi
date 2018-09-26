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
    public class MedicationsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Medications
        public IQueryable<Medications> GetMedications()
        {
            return _context.Medications;
        }

        // GET: api/Medications/5
        [EnableQuery(PageSize = 4)]
        [ResponseType(typeof(Medications))]
        public IHttpActionResult GetMedications(int id)
        {
            var medications = _context.Medications.Where(m => m.UserId == id);
            if (medications == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medications);
        }

        [Route("api/GetMedicationsDetails/{userId}")]
        [ResponseType(typeof(Medications))]
        public IHttpActionResult GetMedicationsDetails(int userId)
        {
            var medications = _context.Medications.Where(m => m.UserId == userId);
            if (medications == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medications);
        }

        [Route("api/GetMedicationsCount/{userId}")]
        [ResponseType(typeof(Medications))]
        public IHttpActionResult GetMedicationsCount(int userId)
        {
            var medications = _context.Medications.Count(i => i.UserId == userId);

            if (medications == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(medications);
        }

        // PUT: api/Medications/5
        [ResponseType(typeof(void))]
        public void PutMedications(int id, MedicationsDto medicationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var medications = _context.Medications.SingleOrDefault(b => b.MedicationsId == id);

            if (medications == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(medicationsDto, medications);

            _context.SaveChanges();
        }

        // POST: api/Medications
        [ResponseType(typeof(Medications))]
        public MedicationsDto PostMedications(MedicationsDto medicationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var medications = Mapper.Map<MedicationsDto, Medications>(medicationsDto);
            _context.Medications.Add(medications);
            _context.SaveChanges();

            medicationsDto.MedicationsId = medications.MedicationsId;

            return medicationsDto;
        }

        // DELETE: api/Medications/5
        [ResponseType(typeof(Medications))]
        public IHttpActionResult DeleteMedications(int id)
        {
            Medications medications = _context.Medications.SingleOrDefault(m => m.MedicationsId == id);
            if (medications == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Medications.Remove(medications);
            _context.SaveChanges();

            return Ok(medications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool MedicationsExists(int id)
        {
            return _context.Medications.Count(e => e.MedicationsId == id) > 0;
        }
    }
}