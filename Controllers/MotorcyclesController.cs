using Microsoft.AspNetCore.Mvc;
using MotorcycleApi.Models;
using MotorcycleApi.Services;

namespace MotorcycleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MotorcyclesController : ControllerBase
    {
        private readonly IMotorcycleService _services;

        public MotorcyclesController(IMotorcycleService service)
        {
            _services = service;
        }

    [HttpGet]

    public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }

    [HttpGet("{Id}")]

    public IActionResult GetById(int Id)
        {
            var tempId = _services.GetById(Id);

            if(tempId == null)
            {
                return NotFound("Producto no encontrado");
            }
            else
            {
                return Ok(tempId);
            }
        }
    
    [HttpPost]

    public IActionResult GetPost(int Id, Motorcycle postMotorcycle)
        {
            var tempPost = _services.GetPost(Id, postMotorcycle);
            return Created($"/api/motorcycles{postMotorcycle.Id}", postMotorcycle);
        }

    [HttpPut("{Id}")]

    public IActionResult GetPut(int Id, Motorcycle postMotorcycle)
        {
            var tempPut = _services.GetPut(Id, postMotorcycle);

            if(tempPut == null)
            {
                return NotFound("Producto no encontrado para actualizar");
            }
            else
            {
                return Ok(tempPut);
            }
        }
    
    [HttpDelete("{Id}")]

    public IActionResult GetDelete (int Id)
        {
            var tempDelete = _services.GetDelete(Id);
            if(tempDelete == null)
            {
                return NotFound("Producto no encontrado para eliminar");
            }
            else
            {
                return Ok("Producto eliminado");
            }
        }
    }
}