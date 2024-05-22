using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class FrontPageController : ControllerBase // Inherits from the base controller class
    {
        private readonly IFrontPageRepository _frontPageRepo; // like a container that holds information about front pages

        public FrontPageController(IFrontPageRepository repo) // Constructor to set up the controller to use FrontPageRepository
        {
            this._frontPageRepo = repo; // Keeps track of the repository instance
        }

        [HttpGet] // this is a DataAnnotation / Attribute / it's a rule. defines what method or class is able to do
        public IEnumerable<FrontPage> GetAll() // Method to get all the front page data
        {
            var result = _frontPageRepo.GetAll(); // brings all of the front page data using the repository
            return result; // Returns the front page data we got
        }
    }
}
