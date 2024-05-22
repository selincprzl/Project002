using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class WeaponController : ControllerBase // Inherits from the base controller class
    {
        private readonly IWeaponRepository _weaponRepo; // like a container that holds information about weapons; readonly means it cannot be changed once set

        public WeaponController(IWeaponRepository repo) // Constructor to set up the controller to use WeaponRepository
        {
            this._weaponRepo = repo; // Keeps track of the repository instance
        }

        [HttpGet] // Attribute indicating that this method handles HTTP GET requests
        public IEnumerable<Weapon> GetAll() // Method to get all the weapon data
        {
            var result = _weaponRepo.GetAll(); // brings all of the weapon data using the repository
            return result; // Returns the weapon data we got
        }
    }
}
