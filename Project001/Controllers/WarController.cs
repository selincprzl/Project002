using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

//This controller is designed to manage operations.
//It interacts with a repository to perform CRUD (Create, Read, Update, Delete) operations on war data.

//Controller is a bridge between API and client(browser). 

namespace Project001.Controllers
{
    [Route("api/[controller]")] // Defines the URL route to access this controller
    [ApiController] // Indicates that this class is a controller for API endpoints
    public class WarController : ControllerBase // Inherits from the base controller class
    {
        private readonly IWarRepository _warRepo; // like a container that holds information about wars

        public WarController(IWarRepository repo) // Constructor to set up the controller to use WarRepository
        {
            this._warRepo = repo; // Keeps track of the repository instance
        }

        [HttpGet] // this is a DataAnnotation / Attribute / it's a rule. defines what method or class is able to do
        public IEnumerable<War> GetAll() // Method to get all the war data
        {
            var result = _warRepo.GetAll(); // brings all of the war data using the repository
            return result; // Returns the war data we got
        }

        [HttpPost] // this method handles HTTP POST requests to create a new war
        public void Create(War war) // Method to create a new war
        {
            _warRepo.Create(war); // Calls the repository to create a new war
        }

        [HttpPut("{id}")] // this method handles HTTP PUT requests to update an existing war
        public ActionResult<War> Update(int id, War war) // Method to update an existing war
        {
            if (id != war.WarId) // Check if the provided ID matches the ID in the request body
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingWar = _warRepo.GetById(id); // Get the existing war from the repository
            if (existingWar == null) // Check if the war exists
            {
                return NotFound(); // Return 404 Not Found if the war does not exist
            }

            war.WarId = id; // Set the ID of the war to be updated

            _warRepo.Update(war); // Update the war in the repository
            return Ok(war); // Return 200 OK with the updated war
        }


        [HttpDelete("{id}")] // this method handles HTTP DELETE requests to delete a war by ID
        public bool Delete(int id) // Method to delete a war by ID
        {
            War warToDelete = _warRepo.GetAll().FirstOrDefault(w => w.WarId == id); // Get the war to delete from the repository

            if (warToDelete == null) // Check if the war exists
            {
                return false; // Return false if the war does not exist
            }

            return _warRepo.Delete(warToDelete); // Delete the war and return true if successful
        }
    }
}
