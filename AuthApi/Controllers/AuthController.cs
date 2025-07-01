using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthApi.Data;
using AuthApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !VerifyPassword(request.Password, user.Password))
                return BadRequest("Usuário ou senha inválidos");

            return Ok(new { 
                success = true, 
                message = "Login realizado com sucesso",
                user = new { user.Id, user.Username, user.Email }
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            //Verificar se usuário já existe
            var existingUser = await _context.Users
                .AnyAsync(u => u.Username == request.Username || u.Email == request.Email);

            if (existingUser)
                return BadRequest("Usuário ou email já existe");

            //Criar novo usuário
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { 
                success = true, 
                message = "Usuário registrado com sucesso",
                user = new { user.Id, user.Username, user.Email }
            });
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}