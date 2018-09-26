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
    public class CitiesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Cities
        public IEnumerable<CitiesDto> GetCities()
        {
            return _context.Cities.ToList().Select(Mapper.Map<Cities, CitiesDto>);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitiesExists(int id)
        {
            return _context.Cities.Count(e => e.CityId == id) > 0;
        }
    }
}