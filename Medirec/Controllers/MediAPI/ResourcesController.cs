using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class ResourcesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Resources
        public IQueryable<Resources> GetResources()
        {
            return _context.Resources;
        }

        // GET: api/Resources/5
        [EnableQuery(PageSize = 10)]
        [ResponseType(typeof(Resources))]
        public IHttpActionResult GetResources(int id)
        {
            var resources = _context.Resources.Where(r => r.UserId == id);
            if (resources == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(resources);
        }

        [Route("api/GetResourcesDetails/{userId}")]
        [ResponseType(typeof(Resources))]
        public IHttpActionResult GetResourcesDetails(int userId)
        {
            var resources = _context.Resources.Where(r => r.UserId == userId);
            if (resources == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(resources);
        }

        [Route("api/GetResourcesCount/{userId}")]
        [ResponseType(typeof(Resources))]
        public IHttpActionResult GetResourcesCount(int userId)
        {
            var resources = _context.Resources.Count(i => i.UserId == userId);

            if (resources == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(resources);
        }

        // PUT: api/Resources/5
        [ResponseType(typeof(void))]
        public void PutResources(int id, ResourcesDto resourcesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var resources = _context.Resources.SingleOrDefault(r => r.ResourcesId == id);

            if (resources == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(resourcesDto, resources);

            _context.SaveChanges();
        }

        // POST: api/Resources
        [ResponseType(typeof(Resources))]
        public IHttpActionResult PostResources(Resources resources)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Resources.Add(resources);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resources.ResourcesId }, resources);
        }

        [HttpPost]
        [Route("api/UploadResourcesPhoto/{resourceId}")]
        public IHttpActionResult UploadResourcesPhoto(int resourceId)
        {
            var resources = _context.Resources.SingleOrDefault(p => p.ResourcesId == resourceId);

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
                        resources.Name = new FileInfo(file.FileName).Name;
                        fileName = id.ToString() + "_" + fileName;
                        file.SaveAs(destinationPath + Path.GetFileName(fileName));
                        resources.ImageUrl = "Documents/" + fileName;
                        _context.Entry(resources).State = EntityState.Modified;
                        _context.SaveChanges();
                        return Ok("OK");
                    }
                }
            }
            return Ok("Photo could not be uploaded..");
        }

        // DELETE: api/Resources/5
        [ResponseType(typeof(Resources))]
        public IHttpActionResult DeleteResources(int id)
        {
            Resources resources = _context.Resources.SingleOrDefault(r => r.ResourcesId == id);
            if (resources == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Resources.Remove(resources);
            _context.SaveChanges();

            return Ok(resources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool ResourcesExists(int id)
        {
            return _context.Resources.Count(e => e.ResourcesId == id) > 0;
        }
    }
}