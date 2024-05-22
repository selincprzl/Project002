using Microsoft.AspNetCore.Mvc;
using Project002.Repository;
using Project002.Repository.Models;
using Project002.Repository.Interfaces;
using Project002.Repository.Repositories;

namespace Project002Api.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class SamuraiController : ControllerBase // Inherits from the base controller class
    {
        private readonly ISamuraiRepository _samuraiRepo; // like a container that holds information about samurais

        public SamuraiController(ISamuraiRepository samuraiRepo) // Constructor to set up the controller to use SamuraiRepository
        {
            _samuraiRepo = samuraiRepo; // Keeps track of the repository instance
        }

        [HttpPost] // Attribute indicating that this method handles HTTP POST requests
        public void Create(Samurai samurai) // Method to create a new samurai
        {
            _samuraiRepo.Create(samurai); // Calls the repository to create a new samurai
        }

        [HttpGet] // Attribute indicating that this method handles HTTP GET requests
        public IEnumerable<Samurai> GetAll() // Method to get all the samurai data
        {
            var result = _samuraiRepo.GetAll(); // Brings all of the samurai data using the repository
            return result; // Returns the samurai data we got
        }
    }
}
