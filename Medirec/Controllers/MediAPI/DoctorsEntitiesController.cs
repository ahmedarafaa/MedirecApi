using Medirec.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace Medirec.Controllers.MediAPI
{
    public class DoctorsEntitiesController : ODataController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult Get()
        {
            return Ok(_context.DoctorsEntities);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return _context.DoctorsEntities.Count(e => e.DoctorId == id) > 0;
        }
    }
}