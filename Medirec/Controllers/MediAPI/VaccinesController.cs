using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Medirec.Controllers.MediAPI
{
    public class VaccinesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Vaccines
        public IEnumerable<VaccinesDto> GetVaccines()
        {
            return _context.Vaccines.ToList().Select(Mapper.Map<Vaccines, VaccinesDto>);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool VaccinesExists(int id)
        {
            return _context.Vaccines.Count(e => e.VaccineId == id) > 0;
        }
    }
}