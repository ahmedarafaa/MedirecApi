using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Medirec.Dtos;
using Medirec.Models;

namespace Medirec.Controllers.MediAPI
{
    public class CountriesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Countries
        public IEnumerable<CountriesDto> GetCountries()
        {
            return _context.Countries.ToList().Select(Mapper.Map<Countries, CountriesDto>);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Count(e => e.CountryId == id) > 0;
        }
    }
}