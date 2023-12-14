using LearningCachingDotnet.Models;
using LearningCachingDotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCachingDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carsService;

        public CarsController(ICarService carService)
        {
            _carsService = carService; 
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var cars = await _carsService.Get(); 
            if(cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId([FromRoute] int id)
        {
            var carId = await _carsService.FindById(id);
            if(carId == null)
            {
                return NotFound();
            }
            return Ok(carId);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Cars cars)
        {
            var create = await _carsService.Create(cars);
            return CreatedAtAction("GetbyId", new { id = create.Id }, create);
        }

        [HttpGet("greeting/{name}")]
        public string Hello([FromRoute] string name)
        {
            var greeting = $"hello {name} el mejor";

            return greeting;
        }
    }
}
