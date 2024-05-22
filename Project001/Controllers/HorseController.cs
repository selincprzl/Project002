using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class HorseController : ControllerBase // Inherits from the base controller class
    {
        private readonly IHorseRepository _horseRepo; // like a container that holds information about horses

        public HorseController(IHorseRepository repo) // Constructor to set up the controller to use HorseRepository
        {
            this._horseRepo = repo; // Keeps track of the repository instance
        }

        [HttpGet] // this is a DataAnnotation / Attribute / it's a rule. defines what method or class is able to do
        public IEnumerable<Horse> GetAll() // Method to get all the horse data
        {
            var result = _horseRepo.GetAll(); // brings all of the horse data using the repository
            return result; // Returns the horse data we got
        }
    }
}
