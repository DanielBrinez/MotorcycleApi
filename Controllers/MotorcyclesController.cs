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

    [HttpGet("available")]

    public async Task <IActionResult> GetAvailableMotorcycless()
        {
            var tempAvailable = await _services.GetAvailableMotorcycless();
            return Ok(tempAvailable);
        }
    
    [HttpGet("Average")]

    public async Task<IActionResult> GetAveragePrice()
        {
            var tempGet = await _services.GetAveragePrice();
            return Ok(tempGet);
        }

    [HttpGet("GetStock")]

    public async Task <IActionResult> GetTotalStock ()
        {
            var tempTotal = await _services.GetTotalStock();
            return Ok(tempTotal);
        }

    [HttpPut("{Id}")]

    public async Task<IActionResult> SellMotorcycle(int Id)
        {
            var tempSell = await _services.SellMotorcycle(Id);
            if(tempSell == null)
            {
                return NotFound("Producto no encontrado para actualizar");
            }
            else
            {
                return Ok(tempSell);
            }
        }

    [HttpGet("GetMost")]

    public async Task<IActionResult> GetMostExpensive()
        {
            var tempGetMost = _services.GetMostExpensive();
            return Ok(tempGetMost);
        }
    }
}