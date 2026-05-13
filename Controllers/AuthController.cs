using Microsoft.AspNetCore.Mvc;
using MotorcycleApi.Services;
using Microsoft.EntityFrameworkCore;
using MotorcycleApi.Models;
using MotorcycleApi.DTOs;
using MotorcycleApi.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotorcycleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly MotorcycleContext _context;

        public AuthController (MotorcycleContext context)
        {
            _context = context;
        }

    [HttpGet("GetAllUsers")]

    public async Task<IActionResult> GetUsersAll()
        {
            var findUsers = await _context.Users.ToListAsync();
            return Ok(findUsers);
        }    

    [HttpPost("Register")]

    public async Task<IActionResult> RegisterUser (LoginRequestDTO logRegister)
        {
            var newUser = new User
            {
                Email = logRegister.Email,
                Password = logRegister.Password
            };
                
                await _context.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return Created("",newUser);
        }

    [HttpPost("Login")]

    public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var authLog = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);
            if(authLog == null)
            {
                return Unauthorized();
            }
            else
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("La_Clave_De_Mi_Api_Es_Muy_Segura_en_Pleno_2026"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);   

                var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

        }

    }
}