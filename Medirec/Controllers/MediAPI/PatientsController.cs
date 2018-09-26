using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Patients
        [Route("api/Patients")]
        [HttpGet]
        public IQueryable<Patients> GetPatients()
        {
            return _context.Patients;
        }

        // GET: api/Patients
        [Route("api/Patients/{userId}")]
        [HttpGet]
        public PatientsDto GetPatients(int userId)
        {
            var patients = _context.Patients.SingleOrDefault(p => p.UserId == userId);

            if (patients == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Patients, PatientsDto>(patients);
        }

        // GET: api/Patients/5
        [HttpGet]
        [Route("api/GetPatientsDetails/{userId}")]
        [ResponseType(typeof(Patients))]
        public IHttpActionResult GetPatientsDetails(int userId)
        {

            var patients =
                from p in _context.Patients.Where(pa => pa.UserId == userId)
                join c in _context.Cities on p.CityId equals c.CityId
                join a in _context.Areas on p.AreaId equals a.AreaId
                //join u in _context.Users on p.UserId equals u.UserId
                select new
                {
                    p.PatientCode,
                    c.NameEn,
                    AreaName = a.NameEn,
                    p.FullName,
                    p.Gender,
                    Age = DateTime.Today.Year - p.BirthDate.Year,
                    p.ImageURL,
                    p.PhoneNumber
                };

            //var patients = _context.Patients.Find(id);
            if (patients == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(patients);
        }

        // PUT: api/Patients/5
        [HttpPut]
        [Route("api/Patients/{userId}")]
        [ResponseType(typeof(void))]
        public void PutPatients(int userId, PatientsDto patientsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var patient = _context.Patients.SingleOrDefault(p => p.UserId == userId);

            if (patient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(patientsDto, patient);

            _context.SaveChanges();
        }

        // POST: api/Patients
        [HttpPost]
        [Route("api/Patients")]
        [ResponseType(typeof(Patients))]
        public PatientsDto PostPatients(PatientsDto patientsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var patient = Mapper.Map<PatientsDto, Patients>(patientsDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientsDto.PatientId = patient.PatientId;

            return patientsDto;
        }

        [HttpPost]
        [Route("api/UploadPatientPhoto/{userId}")]
        public IHttpActionResult UploadPatientPhoto(int userId)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.UserId == userId);

            //return Ok(HttpContext.Current.Server.MapPath(""));

            string destinationPath = @"G:\\PleskVhosts\\medirec.me\\36765264api.medirec.me\\Documents\\";
            HttpFileCollection files = HttpContext.Current.Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.ContentLength > 0)
                {
                    string fileName = new FileInfo(file.FileName).Name;
                    string fileExtention = new FileInfo(file.FileName).Extension;

                    if (fileExtention == ".jpg" || fileExtention == ".png")
                    {
                        Guid id = Guid.NewGuid();
                        fileName = id.ToString() + "_" + fileName;
                        file.SaveAs(destinationPath + Path.GetFileName(fileName));
                        patient.ImageURL = "Documents/" + fileName;
                        _context.Entry(patient).State = EntityState.Modified;
                        _context.SaveChanges();
                        return Ok("OK");
                    }
                }
            }
            return Ok("Photo could not be uploaded..");
        }

        // GET: api/Patients
        [Route("api/UploadPatientPhoto/{userId}")]
        public IQueryable<Patients> GetImage(int userId)
        {
            return _context.Patients;
        }

        // DELETE: api/Patients/5
        [Route("api/Patients/{userId}")]
        [HttpDelete]
        [ResponseType(typeof(Patients))]
        public IHttpActionResult DeletePatients(int userId)
        {
            Patients patients = _context.Patients.SingleOrDefault(p => p.UserId == userId);
            if (patients == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patients);
            _context.SaveChanges();

            return Ok(patients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientsExists(int id)
        {
            return _context.Patients.Count(e => e.PatientId == id) > 0;
        }
    }
}