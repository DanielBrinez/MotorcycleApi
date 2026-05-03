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
            var tempGet = _services.GetAll();
            return Ok(tempGet);
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

    public IActionResult GetPost(Motorcycle receivedesmotorcycles)
        {
            var tempPost = _services.GetPost(receivedesmotorcycles);
            return Created($"/api/motorcycles{receivedesmotorcycles.Id}", receivedesmotorcycles);
        }

    [HttpPut("{Id}")]

    public IActionResult GetPut(int Id, Motorcycle UpdatedMotorcycle)
        {
            var tempPut = _services.GetPut(Id, UpdatedMotorcycle);
            if(tempPut == null)
            {
                return NotFound("Producto no encontrado para actualizar");
            }
            else
            {
                return Ok(tempPut);
            }
        }
    
    [HttpDelete]

    public IActionResult GetDelete(int Id)
        {
            var tempDelete = _services.GetDelete(Id);
            if(tempDelete == null)
            {
                return NotFound("Producto no encontrado");
            }
            else
            {
                return Ok("Producto eliminado correctamente");
            }
        }
    }
}