using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackJack.Data;
using BlackJack.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BlackJack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly BlackJackContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(BlackJackContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.User.Any(u => u.Cedula == userRegister.Cedula))
            {
                return BadRequest("Cedula ya registrada.");
            }

            if (_context.User.Any(u => u.Email == userRegister.Email))
            {
                return BadRequest("Correo ya registrado, intenta con otro.");
            }

            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                return BadRequest("Las contraseñas no coinciden");
            }

            try
            {
                var user = new User
                {
                    Cedula = userRegister.Cedula,
                    Name = userRegister.Name,
                    LastName = userRegister.LastName,
                    Email = userRegister.Email,
                    Phone = userRegister.Phone,
                    Password = userRegister.Password,
                    ConfirmPassword = userRegister.ConfirmPassword
                };

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Cedula == userLogin.Cedula);

            if (user == null)
            {
                return BadRequest("Cedula no encontrada, registrate!");
            }

            if (user.Password != userLogin.Password)
            {
                return BadRequest("Cédula o contraseña incorrecta");
            }

            var token = GenerateJwtToken(user);
            return Ok(new { token, user });
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    // Puedes agregar más claims según lo necesites
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }


}   
