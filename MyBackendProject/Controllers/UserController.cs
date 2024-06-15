// Controllers/UserController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.Data;
using MyBackendProject.DTOs;
using MyBackendProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyInfo()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = userIdClaim.Value;
            var user = await _context.Users.FindAsync(int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Username,
                user.Email
            });
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyInfo([FromBody] UserInfoDto dto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = userIdClaim.Value;
            var user = await _context.Users.FindAsync(int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            user.Username = dto.Username ?? user.Username;
            user.Email = dto.Email ?? user.Email;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
