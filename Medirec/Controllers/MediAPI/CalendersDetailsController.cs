using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class CalendersDetailsController : ODataController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [EnableQuery]
        public IHttpActionResult Get()
        {
            var dateNow = DateTime.Now;

            var calenderDetails = _context.CalendersDetails;

            return Ok(calenderDetails);
        }


        //// GET: api/CalendersDetails/5
        //[EnableQuery(/*PageSize =6*/)]
        ////[Route("api/CalendersDetails/{doctorId}/{entityId}")]
        //[ResponseType(typeof(CalendersDetails))]
        //public IHttpActionResult GetCalendersDetails(/*int doctorId, int entityId*/)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    //var calendersDetails = _context.CalendersDetails.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

        //    var calendersDetails =
        //        from c in _context.CalendersDetails
        //            //.Where(c => c.DoctorId == doctorId & c.EntityId == entityId)
        //        orderby c.Date
        //        select new
        //        {
        //            c.CalendersDetailsId,
        //            c.CalendersId,
        //            c.DoctorId,
        //            c.EntityId,
        //            c.Date,
        //            c.DayName,
        //            c.TimeFrom,
        //            c.TimeTo,
        //            c.IsReserved
        //        };

        //    //var calender = from c in _context.Calenders
        //    //               //join cd in _context.CalendersDetails on c.CalendersId equals cd.CalendersId
        //    //               select new
        //    //               {
        //    //                   c.DoctorId,
        //    //                   c.EntityId,
        //    //                   //c.CalendersId,
        //    //                   Date = _context.CalendersDetails.Where(cd => cd.CalendersId == c.CalendersId).Select(cd => cd.Date)
        //    //               };

        //    //var calender =
        //    //    from cd in _context.CalendersDetails.Where(cd => cd.DoctorId == 89 & cd.EntityId == 21)
        //    //    orderby cd.Date
        //    //    select new
        //    //    {
        //    //        cd.DoctorId,
        //    //        cd.EntityId,
        //    //        cd.DayName,
        //    //        cd.Date,
        //    //        TimeFrom = _context.CalendersDetails
        //    //            .Where(d => d.Date == cd.Date & d.DoctorId == cd.DoctorId & d.EntityId == cd.EntityId)
        //    //            .Select(d => d.TimeFrom)
        //    //    };

        //    //var calender =
        //    //    from c in _context.Calenders
        //    //    select new
        //    //    {
        //    //        c.DoctorId,
        //    //        c.EntityId

        //    //    };

        //    //var calender = 
        //    //    from c in _context.Calenders
        //    //    join cd in _context.CalendersDetails on c.CalendersId equals cd.CalendersId into g
        //    //    select new {}

        //    if (calendersDetails == null)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    return Ok(calendersDetails);
        //}



        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool CalendersDetailsExists(int id)
        {
            return _context.CalendersDetails.Count(e => e.CalendersDetailsId == id) > 0;
        }
    }
}