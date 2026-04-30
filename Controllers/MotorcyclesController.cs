using MotorcycleApi.Models;
using MotorcycleApi.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("SelectProduct")]

    public IActionResult SelectOrders()
        {
            var findOrders = _services.SelectOrders();
            return(findOrders);
        }

    [HttpGet("Orders")]

    public IActionResult GetOrder()
        {
            var tempOrder= _services.GetOrder();
            return Ok(tempOrder);
        }

    [HttpGet("Price")]

    public IActionResult GetAllPrice()
        {
            var allPrice = _services.GetAllPrice();
            return Ok(allPrice);
        }

    [HttpGet]

    public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }

    [HttpGet("{Id}")]

    public IActionResult GetById(int Id)
        {
            var tempid = _services.GetById(Id);
            if(tempid == null)
            {
                return NotFound("Producto no encontrado");
            }
            else
            {
                return Ok(tempid);
            }
        }

    [HttpPost]

    public IActionResult GetPost (Motorcycle createdMotorcycle)
        {
            var tempPost = _services.GetPost(createdMotorcycle);
            return Created($"/api/controllers,{createdMotorcycle.Id}", createdMotorcycle);
        }

    [HttpPut("{Id}")]

    public IActionResult GetPut(int Id, Motorcycle createdMotorcycle)
        {
            var putTemp = _services.GetPut(Id, createdMotorcycle);
            if(putTemp == null)
            {
                return NotFound("Producto no encontrado para actualizar");
            }
            else
            {
                return Ok(putTemp);
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
                return Ok("producto eliminado");
            }
        }
    }
}