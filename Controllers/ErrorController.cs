using Microsoft.AspNetCore.Mvc;

namespace MotorcycleApi.Controllers
{
    [ApiController]
    
    public class ErrorController : ControllerBase
    {
        [Route("/error")]

        public IActionResult Error()
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }
}