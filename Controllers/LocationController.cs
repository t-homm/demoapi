using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demoApi.Models;
using NetTopologySuite.Geometries;


namespace demoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationContext _context;
        public LocationController(LocationContext context)
        {
            _context = context;
        }

        //　GET : api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations(Double lat,Double lng)
        {

            var data = await _context.Locations
                .Where(c => c.GeographicalPoint.Distance(new Point(lng, lat) {SRID = 4326})<=1000)
                .ToArrayAsync();
            
            List<resLocation> result = new List<resLocation>();

            foreach( var x in data)
            {
                resLocation list = new resLocation();
                Console.WriteLine(x.Name.ToString());

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
public class resLocation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string Address { get;  set; }
    public string Tel { get; set; }
}