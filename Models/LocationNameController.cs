using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoApi.Models;

namespace demoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationNameController : ControllerBase
    {
        private readonly LocationContext _context;

        public LocationNameController(LocationContext context)
        {
            _context = context;
        }

        // GET: api/LocationName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations(String name)
        {
            var data = await Task.Run(() => _context.Locations.Where(c => c.Name.Contains(name)));

            List<resLocation> result = new List<resLocation>();

            foreach(var x in data)
            {
                resLocation list = new resLocation();

                list.Name = x.Name.ToString();
                list.Id = x.Id;
                list.Address = x.Address.ToString();
                list.latitude = x.GeographicalPoint.Y.ToString();
                list.longitude = x.GeographicalPoint.X.ToString();
                list.Tel = x.Tel.ToString();
                result.Add(list);
            }

            object obj = new {status="success",data=result};
            return new JsonResult(obj);

        }


    }
}