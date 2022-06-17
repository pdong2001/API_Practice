using Library.ServiceLayer.Tours;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourService tour;

        public ToursController(ITourService tour)
        {
            this.tour = tour;
        }

        [HttpGet]
        public IActionResult GetAllTour([FromQuery] string search)
        {
            return Ok(tour.GetAllTours(search));
        }

        [HttpPost]
        public IActionResult AddTour([FromBody] InsertUpdateTourDto input)
        {
            return Ok(tour.AddTour(input));
        }

        [HttpPut("{id}")]
        public IActionResult EditTour([FromRoute] Guid id,[FromBody] InsertUpdateTourDto input)
        {
            return Ok(tour.EditTour(id,input));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTour([FromRoute] Guid id)
        {
            return Ok(tour.DeleteTour(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetTourById([FromRoute] Guid id)
        {
            return Ok(tour.GetTourById(id));
        }


        [HttpGet("order/{id}")]
        public IActionResult GetOrder([FromRoute] Guid id)
        {
            return Ok(tour.GetOrder(id));
        }

        [HttpGet("report")]
        public IActionResult ReportTour([FromQuery] TourLookUpDto request)
        {
            return Ok(tour.ReportTours(request));
        }
    }
}
