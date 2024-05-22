using Microsoft.AspNetCore.Mvc; 
using Project002.Repository.Interfaces; 
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers 

{

    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class ArmourController : ControllerBase // Inherits from the base controller class
    {
        private readonly IArmourRepository _armourRepo; // like a container that holds information about armours

        public ArmourController(IArmourRepository repo) // Constructor to set up the controller to use ArmourRepository
        {
            this._armourRepo = repo; // Keeps track of the repository instance
        }

        [HttpGet] // this is a DataAnnotation / Attribute / it's a rule. defines what method or class is able to do
        public IEnumerable<Armour> GetAll() // Method to get all the armour data
        {
            var result = _armourRepo.GetAll(); // brings all of the armour data using the repository
            return result; // Returns the armour data we got
        }
    }
}
