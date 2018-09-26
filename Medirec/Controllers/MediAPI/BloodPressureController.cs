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

namespace Medirec.Controllers.MediAPI
{
    public class BloodPressureController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/BloodPressure
        public IQueryable<BloodPressure> GetBloodPressure()
        {
            return _context.BloodPressure;
        }

        
        [Route("api/GetBloodPressureDetails/{userId}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetBloodPressureDetails(int userId)
        {
            var bloodPressure = _context.BloodPressure.Where(b => b.UserId == userId);
            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<BloodPressure, BloodPressureDto>(bloodPressure);
            return Ok(bloodPressure);
        }

        [Route("api/GetBloodPressureCount/{userId}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetBloodPressureCount(int userId)
        {
            var bloodPressure = _context.BloodPressure.Count(i => i.UserId == userId);

            if (bloodPressure <= 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<BloodPressure, BloodPressureDto>(bloodPressure);
            return Ok(bloodPressure);
        }

        [Route("api/GetPressuresPerDays/{userId:int}/{days:int}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetPressuresPerDays(int userId, int days)
        {
            //DateTime lessThanXDays = DateTime.Now.AddDays(-(days+1));
            DateTime lessThanXDays = DateTime.Now.AddDays(-(days));

            var bloodPressure = _context.BloodPressure
                .OrderByDescending(bP => bP.Date)
                .Where(b => b.Date > lessThanXDays & b.Date <= DateTime.Now & b.UserId == userId);

            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(bloodPressure);
        }

        [Route("api/GetPressuresFromTo/{userId:int}/{fromDate:DateTime}/{toDate:DateTime}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetPressuresFromTo(int userId, DateTime fromDate, DateTime toDate)
        {

            var toDateP = toDate.AddDays(1);
            var bloodPressure = _context.BloodPressure.OrderByDescending(bP => bP.Date)
                .Where(b => (b.Date >= fromDate & b.Date <= toDateP) & b.UserId == userId);

            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(bloodPressure);
        }

        // PUT: api/BloodPressure/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutBloodPressure(int id, BloodPressureDto bloodPressureDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodPressure = _context.BloodPressure.SingleOrDefault(b => b.BloodPressureId == id);

            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(bloodPressureDto, bloodPressure);

            _context.SaveChanges();
        }

        // POST: api/BloodPressure
        [ResponseType(typeof(BloodPressure))]
        public BloodPressureDto PostBloodPressure(BloodPressureDto bloodPressureDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodPressure = Mapper.Map<BloodPressureDto, BloodPressure>(bloodPressureDto);
            _context.BloodPressure.Add(bloodPressure);
            _context.SaveChanges();

            bloodPressureDto.BloodPressureId = bloodPressure.BloodPressureId;

            return bloodPressureDto;

        }

        // DELETE: api/BloodPressure/5
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult DeleteBloodPressure(int id)
        {
            BloodPressure bloodPressure = _context.BloodPressure.SingleOrDefault(b => b.BloodPressureId == id);
            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BloodPressure.Remove(bloodPressure);
            _context.SaveChanges();

            return Ok(bloodPressure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodPressureExists(int id)
        {
            return _context.BloodPressure.Count(e => e.BloodPressureId == id) > 0;
        }
    }
}