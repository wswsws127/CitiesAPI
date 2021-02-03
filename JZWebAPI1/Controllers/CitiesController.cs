using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JZWebAPI1.Controllers
{
    [ApiController]
    [Route("api/cities")] //add prefix to all the actions in this controller
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            #region return IActionResult: statusCode + content
            return Ok(CitiesDataStore.Current.Cities);
            #endregion

            #region return JsonResult
            return new JsonResult(CitiesDataStore.Current.Cities);
            #endregion

            #region return 匿名object
            //return new JsonResult(
            // new List<object>()
            //{
            //    new {id=1,Name="New York"},
            //    new {id=2,Name="Beijing"}
            //});
            #endregion
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id) {
            #region return IActionResult: statusCode + content
            //find city:
            var cityfound = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==id);
            if (cityfound == null)
            {
                return NotFound();
            }
            return Ok(cityfound);
            #endregion

            #region return JsonResult:
            //return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==id));
            #endregion
        }


    }
}
