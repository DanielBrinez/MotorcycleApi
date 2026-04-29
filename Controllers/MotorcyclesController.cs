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
        
        public MotorcyclesController (IMotorcycleService service)
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
            var findiD = _services.GetById(Id);
            if(findiD == null)
            {
                return NotFound("Producto no encontrado");
            }
            else
            {
                return Ok(findiD);
            }
        }
    [HttpPost]

    public IActionResult PostId(Motorcycle receivedMotorcycle)
        {
            var postTemp = _services.PostId(receivedMotorcycle);
            return Created($"/api/motorcycles{receivedMotorcycle.Id}", receivedMotorcycle);
        }

    [HttpPut("{Id}")]

    public IActionResult PutId (int Id, Motorcycle updatedMotorcycle)
        {
            var tempPut = _services.PutId(Id, updatedMotorcycle);

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