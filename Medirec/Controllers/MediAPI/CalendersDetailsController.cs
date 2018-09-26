using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class CalendersDetailsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // GET: api/CalendersDetails/5
        [EnableQuery]
        //[Route("api/CalendersDetails/{doctorId}/{entityId}")]
        [ResponseType(typeof(CalendersDetails))]
        public IHttpActionResult GetCalendersDetails(/*int doctorId, int entityId*/)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //var calendersDetails = _context.CalendersDetails.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            var calendersDetails =
                from c in _context.CalendersDetails
                    //.Where(c => c.DoctorId == doctorId & c.EntityId == entityId)
                orderby c.Date
                select new
                {
                    c.CalendersDetailsId,
                    c.CalendersId,
                    c.DoctorId,
                    c.EntityId,
                    c.Date,
                    c.DayName,
                    c.TimeFrom,
                    c.TimeTo,
                    c.IsReserved
                };

            //var calender = from c in _context.Calenders
            //               //join cd in _context.CalendersDetails on c.CalendersId equals cd.CalendersId
            //               select new
            //               {
            //                   c.DoctorId,
            //                   c.EntityId,
            //                   //c.CalendersId,
            //                   Date = _context.CalendersDetails.Where(cd => cd.CalendersId == c.CalendersId).Select(cd => cd.Date)
            //               };

            //var calender =
            //    from cd in _context.CalendersDetails.Where(cd => cd.DoctorId == 89 & cd.EntityId == 21)
            //    orderby cd.Date
            //    select new
            //    {
            //        cd.DoctorId,
            //        cd.EntityId,
            //        cd.DayName,
            //        cd.Date,
            //        TimeFrom = _context.CalendersDetails
            //            .Where(d => d.Date == cd.Date & d.DoctorId == cd.DoctorId & d.EntityId == cd.EntityId)
            //            .Select(d => d.TimeFrom)
            //    };

            //var calender =
            //    from c in _context.Calenders
            //    select new
            //    {
            //        c.DoctorId,
            //        c.EntityId

            //    };

            //var calender = 
            //    from c in _context.Calenders
            //    join cd in _context.CalendersDetails on c.CalendersId equals cd.CalendersId into g
            //    select new {}

            if (calendersDetails == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok(calendersDetails);
        }

        //EntityType --> 0 --> Calender from to
        //EntityType --> 1 --> Generate Calender per minutes 
        [Route("api/CalendersDetails/{doctorId}/{entityId}/{generateDays}/{calenderTypeId}")]
        [ResponseType(typeof(CalendersDetails))]
        public IHttpActionResult PostCalendersDetails(int doctorId, int entityId, int generateDays, int calenderTypeId)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //delete all records from database

            var deleteCalenderDetails = _context.CalendersDetails.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            _context.CalendersDetails.RemoveRange(deleteCalenderDetails);
            _context.SaveChanges();

            //Generate calender
            var calenders = _context.Calenders.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            if (calenders == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Generate calender when calenderTypeId = 0
            if (calenderTypeId == CalenderTypes.BasicCalender)
            {
                for (int i = 0; i < generateDays; i++)
                {
                    foreach (var item in calenders)
                    {
                        if (item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                        {
                            var cDetails = new CalendersDetails
                            {
                                CalendersId = item.CalendersId,
                                EntityId = entityId,
                                DoctorId = doctorId,
                                TimeFrom = item.TimeFrom,
                                TimeTo = item.TimeTo,
                                Date = DateTime.Now.AddDays(+i),
                                DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                            };
                            _context.CalendersDetails.Add(cDetails);
                        }
                    }
                }
            }


            //Generate calender when calenderTypeId = 1

            if (calenderTypeId == CalenderTypes.TimerCalender)
            {
                for (int i = 0; i < generateDays; i++)
                {
                    foreach (var item in calenders)
                    {
                        if (item.TimeFrom == item.TimeTo && item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                        {
                            var cDetails = new CalendersDetails
                            {
                                CalendersId = item.CalendersId,
                                EntityId = entityId,
                                DoctorId = doctorId,
                                TimeFrom = item.TimeFrom,
                                Date = DateTime.Now.AddDays(+i),
                                DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                            };
                            _context.CalendersDetails.Add(cDetails);
                        }

                        for (var j = item.TimeFrom; j < item.TimeTo; j = j + TimeSpan.FromMinutes(item.GenerateEveryXMin))
                        {
                            if (item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                            {
                                var cDetails = new CalendersDetails
                                {
                                    CalendersId = item.CalendersId,
                                    EntityId = entityId,
                                    DoctorId = doctorId,
                                    TimeFrom = j,
                                    Date = DateTime.Now.AddDays(+i),
                                    DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                                };
                                _context.CalendersDetails.Add(cDetails);
                            }
                        }
                    }
                }

            }


            _context.SaveChanges();
            return Ok();

        }

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