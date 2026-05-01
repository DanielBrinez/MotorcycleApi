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
            try
            {
               var findOrders = _services.SelectOrders();
               return Ok(findOrders);   
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    [HttpGet("Orders")]

    public IActionResult GetOrder()
        {
            try
            {
                var tempOrder= _services.GetOrder();
                return Ok(tempOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    [HttpGet("Price")]

    public IActionResult GetAllPrice()
        {
            try
            {
                var allPrice = _services.GetAllPrice();
                return Ok(allPrice);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
            
        }

    [HttpGet]

    public IActionResult GetAll()
        {
          try

             {
               return Ok(_services.GetAll());
             }
            
          catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
            
        }

    [HttpGet("{Id}")]

    public IActionResult GetById(int Id)
       {
         try
             {
              var tempid = _services.GetById(Id);
              if(tempid == null)
        {
            return NotFound("Producto no encontrado");
        }
        return Ok(tempid);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Error interno del servidor");
    }
}

    [HttpPost]

    public IActionResult GetPost (Motorcycle createdMotorcycle)
        {
            try
            {
                var tempPost = _services.GetPost(createdMotorcycle);
                return Created($"/api/controllers,{createdMotorcycle.Id}", createdMotorcycle);   
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    [HttpPut("{Id}")]

    public IActionResult GetPut(int Id, Motorcycle createdMotorcycle)
        {
            try
            {
                var putTemp = _services.GetPut(Id, createdMotorcycle);
                if(putTemp == null)
                {
                    return NotFound("Producto no encontrado para actualizar");
                }
                return Ok(putTemp);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    [HttpDelete("{Id}")]

    public IActionResult GetDelete (int Id)
        {
            try
            {
               var tempDelete = _services.GetDelete(Id);
               if(tempDelete == null)
                {
                   return NotFound("Producto no encontrado para eliminar");
                }
                return Ok("producto eliminado");   
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}