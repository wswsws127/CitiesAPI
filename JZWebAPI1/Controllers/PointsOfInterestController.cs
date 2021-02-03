using JZWebAPI1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JZWebAPI1.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId) {
            var cityfound = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (cityfound == null)
            {
                return NotFound();
            }
            return Ok(cityfound.PointsOfInterest);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            //find city
            var cityfound = CitiesDataStore.Current.Cities
                .FirstOrDefault(c=>c.Id==cityId);


            if (cityfound == null)
            {
                return NotFound();
            }

            //find point of interest
            var pointOfInterest = cityfound.PointsOfInterest
                .FirstOrDefault(p=>p.Id==id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);

        }

        [HttpPost]
        public IActionResult CreaePointOfInterest(int cityId,
           [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            var cityfound = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==cityId);
            if (cityfound==null)
            {
                return NotFound();
            }
        }
    }
}
