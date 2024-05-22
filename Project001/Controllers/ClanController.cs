using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;


namespace Project001.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class ClanController : ControllerBase // Inherits from the base controller class
    {
        private readonly IClanRepository _clanRepo; // like a container that holds informations about clan


        public ClanController(IClanRepository repo) // Constructor to set up the controller to use ClanRepository. (signature)
        {
            this._clanRepo = repo; // Keeps track of the repository instance.
        }

        [HttpGet] // //this is a DataAnnotation / Attribute /its a rule. defines what method or class is able to do 
        public IEnumerable<Clan> GetAll() // Method to get all the clan data
        {
            var result = _clanRepo.GetAll(); // brings all of the clan data using the repository
            return result; // Returns the clan data we got
        }
    }
}
