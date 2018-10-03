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
    public class GenerateCalenderDetailsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

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

            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");

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
                                //TimeFrom = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(item.TimeFrom.ToString())),
                                //TimeTo = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(item.TimeTo.ToString())),
                                //Date = DateTime.Now.AddDays(+i).ToShortDateString(),
                                //TimeFrom = DateTime.Now.AddDays(+i).AddMinutes(-DateTime.Now.Minute),


                                TimeFrom = DateTime.Today.AddDays(+i) + item.TimeFrom,
                                //TimeFrom = DateTime.SpecifyKind(DateTime.Today.AddDays(+i),DateTimeKind.Utc),
                                //TimeFrom = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo),
                                TimeTo = DateTime.Today.AddDays(+i) + item.TimeTo,

                                //Date = Convert.ToDateTime(DateTime.Now.AddDays(+i).ToShortDateString()),
                                Date = Convert.ToDateTime(DateTime.Now.AddDays(+i).ToShortDateString()),
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
                                TimeFrom = DateTime.Today.AddDays(+i) + item.TimeFrom,
                                TimeTo = DateTime.Today.AddDays(+i) + item.TimeTo,
                                //TimeFrom = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(item.TimeFrom.ToString())),
                                //TimeTo = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(item.TimeTo.ToString())),
                                Date = Convert.ToDateTime(DateTime.Now.AddDays(+i).ToShortDateString()),
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
                                    //TimeFrom = j,
                                    //TimeTo = j + TimeSpan.FromMinutes(item.GenerateEveryXMin),
                                    //TimeFrom = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(j.ToString())),
                                    //TimeTo = string.Format("{0:hh:mm:ss tt}", Convert.ToDateTime(Convert.ToString(j + TimeSpan.FromMinutes(item.GenerateEveryXMin)))),
                                    TimeFrom = DateTime.Today.AddDays(+i) + j,
                                    TimeTo = DateTime.Today.AddDays(+i) + j + TimeSpan.FromMinutes(item.GenerateEveryXMin),
                                    Date = Convert.ToDateTime(DateTime.Now.AddDays(+i).ToShortDateString()),
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