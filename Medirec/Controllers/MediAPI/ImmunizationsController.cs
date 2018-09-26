using System.Collections.Generic;
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
    public class ImmunizationsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Immunizations

        [HttpGet]
        [Route("api/Immunizations")]
        public IEnumerable<ImmunizationsDto> GetImmunizations()
        {
            return _context.Immunizations.ToList().Select(Mapper.Map<Immunizations, ImmunizationsDto>);
        }

        //GET: api/Immunizations/5
        [EnableQuery(PageSize = 10)]
        [HttpGet]
        [Route("api/Immunizations/{userId}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizations(int userId)
        {
            var immunizations = _context.Immunizations.Where(im => im.UserId == userId)
                .Join(_context.Vaccines, i => i.VaccineId, v => v.VaccineId,
                (immunization, vaccine) => new
                {
                    immunizationId = immunization.ImmunizationId,
                    VaccineName = vaccine.Name,
                    immunization.DateGiven,
                    immunization.AdministratedBy,
                    immunization.NextDoesDate
                }
                );

            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        [Route("api/GetImmunizationsDetails/{userId}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizationsDetails(int userId)
        {
            var immunizations = _context.Immunizations.Where(i => i.UserId == userId);
            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        [Route("api/GetImmunizationsCount/{userId}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizationsCount(int userId)
        {
            var immunizations = _context.Immunizations.Count(i => i.UserId == userId);

            if (immunizations == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        // PUT: api/Immunizations/5
        [HttpPut]
        [Route("api/Immunizations/{id}")]
        [ResponseType(typeof(void))]
        public void PutImmunizations(int id, [FromBody]ImmunizationsDto immunizationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var immunizations = _context.Immunizations.SingleOrDefault(i => i.ImmunizationId == id);

            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(immunizationsDto, immunizations);

            _context.SaveChanges();
        }

        // POST: api/Immunizations
        [HttpPost]
        [Route("api/Immunizations")]
        [ResponseType(typeof(Immunizations))]
        public ImmunizationsDto PostImmunizations(ImmunizationsDto immunizationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var immunizations = Mapper.Map<ImmunizationsDto, Immunizations>(immunizationsDto);
            _context.Immunizations.Add(immunizations);
            _context.SaveChanges();

            immunizationsDto.ImmunizationId = immunizations.ImmunizationId;

            return immunizationsDto;
        }

        // DELETE: api/Immunizations/5
        [HttpDelete]
        [Route("api/Immunizations/{id}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult DeleteImmunizations(int id)
        {
            var immunizations = _context.Immunizations.SingleOrDefault(i => i.ImmunizationId == id);
            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Immunizations.Remove(immunizations);
            _context.SaveChanges();

            return Ok(immunizations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool ImmunizationsExists(int id)
        {
            return _context.Immunizations.Count(e => e.ImmunizationId == id) > 0;
        }
    }
}