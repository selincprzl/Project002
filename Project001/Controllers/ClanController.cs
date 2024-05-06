using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController]
    public class ClanController : ControllerBase
    {
        //_clanRepo is like a container that holds information about clans
        //readonly means once it's set, it can't be changed
        private readonly IClanRepository _clanRepo;


        //This sets up the ClanController to use a repository for clans, storing it as _clanRepo.
        public ClanController (IClanRepository repo)
        {
            this._clanRepo = repo;
        }

        // Method that brings all the clans
        //IEnumerable here means that GetAll() returns a list of Clan objects that you can loop through
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public IEnumerable<Clan> GetAll()
        {
            var result = _clanRepo.GetAll();
            return result;

        }

      
        //This code creates a new clan by passing a Clan object to the _clanRepo.Create() method.(signature)
        [HttpPost]
        public void Create (Clan clan)
        {
            _clanRepo.Create(clan);
        }

        //This method updates a clan with the specified ID using the provided clan object
        [HttpPut("{id}")]
        public ActionResult<Clan> Update(int id, Clan clan)
        {
            //checks if the ID in the URL path matches the ID in the provided clan object, if not it returns with a text
            if (id != clan.ClanId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            //This code finds the clan with the given ID in the repository.
            //If it doesn't exist, it returns a "Not Found" response.
            var existingClan = _clanRepo.GetById(id);
            if (existingClan == null)
            {
                return NotFound();
            }

            //updates the clan's ID, saves the changes, and confirms the update.
            clan.ClanId = id;

            _clanRepo.Update(clan);
            return Ok(clan);
        }

        //gets the clans by id
        [HttpGet("{id}")] 
        public ActionResult<Clan> GetById(int id)
        {   
            // If the clan is found, it returns the clan object
            var clan = _clanRepo.GetById(id);
            if (clan == null)
            {
                //If not, it returns a "Not Found" response.
                return NotFound();
            }
            return clan;
        }


        // a method that deletes a Clan
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            //checks if there is an id called frx="1" in the repository
            Clan countryToDelete = _clanRepo.GetAll().FirstOrDefault(c=> c.ClanId == id);
            
            //if yes then its deleted, if no then it returns false.
            if(countryToDelete == null)
            {
                return false;
            }

            return _clanRepo.Delete(countryToDelete);
        }
    }
}
