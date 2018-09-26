using Medirec.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Medirec.Controllers.MediAPI
{
    public class AreasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Areas/5
        [ResponseType(typeof(Areas))]
        public IHttpActionResult GetAreas(int id)
        {
            var areas = db.Areas.Where(a => a.CityId == id);

            if (areas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(areas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool AreasExists(int id)
        {
            return db.Areas.Count(e => e.AreaId == id) > 0;
        }
    }
}