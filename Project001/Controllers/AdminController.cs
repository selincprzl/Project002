// Example: AdminController.cs
using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepo;

        public AdminController(IAdminRepository adminService)
        {
            _adminRepo = adminService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Admin model)
        {
            // Call your service method to authenticate the admin
            bool isAuthenticated = await _adminRepo.VerifyPasswordAsync(model.Email, model.Password);

            if (isAuthenticated)
            {
                // If authentication is successful, return Ok result
                return Ok("Admin authenticated successfully.");
            }
            else
            {
                // If authentication fails, return BadRequest result with error message
                return BadRequest("Invalid email or password.");
            }
        }
    }
}
