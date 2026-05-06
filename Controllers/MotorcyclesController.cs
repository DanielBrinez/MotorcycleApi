using Microsoft.AspNetCore.Mvc;
using MotorcycleApi.Models;
using MotorcycleApi.Services;
using MotorcycleApi.DTOs;

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

    [HttpPut("{Id}/sell")]

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

    [HttpGet("GetMotorcyclesWithStock")]

    public async Task<IActionResult> GetMotorcyclesWithStock ()
        {
            var getTemp = await _services.GetMotorcyclesWithStock();
            return Ok(getTemp);
        }

    [HttpGet("GetExpensiveMotorcycles")]

    public async Task<IActionResult> GetExpensiveMotorcycles ()
        {
            var getExpensive = await _services.GetExpensiveMotorcycles();
            return Ok(getExpensive);
        }

    [HttpGet("GetCheapMotorcycles")]

    public async Task <IActionResult> GetCheapMotorcycles()
        {
            var tempGetCheap = await _services.GetCheapMotorcycles();
            return Ok(tempGetCheap);
        }

    [HttpGet("DiscountedMotorcyclePrice")]

    public async Task<IActionResult> DiscountedMotorcyclePrice()
        {
            var tempDiscount = await _services.DiscountedMotorcyclePrice();
            return Ok(tempDiscount);
        }

    [HttpGet("TotalMotorcycle")]

    public async Task<IActionResult> TotalMotorcycle()
        {
            var tempTotalMotorcycle = await _services.TotalMotorcycle();
            return Ok(tempTotalMotorcycle);
        }

    [HttpGet("GetTop3")]

    public async Task<IActionResult> GetTop3MostExpensive()
        {
            var tempGetTop3 = await _services.GetTop3MostExpensive();
            return Ok(tempGetTop3);
        }

    [HttpPost("CreateMotorcycle")]

    public async Task<IActionResult> CreateMotorcycle (MotorcycleRequestDTO receivedMotorcycle)
        {
            var tempCreate = await _services.CreateMotorcycle(receivedMotorcycle);
            return Created($"/api/motorcycles{tempCreate.Id}", receivedMotorcycle);
        }

    [HttpPut("{Id}/update")]

    public async Task<IActionResult> UpdateMotorcycle (int Id, MotorcycleRequestDTO DeleteMotorcycle)
        {
            var tempUpdated = await _services.UpdateMotorcycle(Id, DeleteMotorcycle);
            if(tempUpdated == null)
            {
                return NotFound("Producto no encontrado para actualizar");
            }
            else
            {
                return Ok(tempUpdated);
            }
        }

    [HttpDelete("{Id}")]

    public async Task<IActionResult> DeleteMotorcycle(int Id)
        {
            var tempDeleteMotorcycle = await _services.DeleteMotorcycle(Id);
            if(tempDeleteMotorcycle == null)
            {
                return NotFound("Producto no encontrado para eliminar");
            }
            else
            {
                return Ok("Producto eliminado éxitosamente");
            }
        }
    }
}