using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;


namespace Project001.Controllers
{
    [Route("api/[controller]")] //our url
    [ApiController]
    public class ArmourController : ControllerBase

    {   //_armourRepo is like a container that holds informations about armours
        //readonly means, it cannot be changed once its set.
        private readonly IArmourRepository _armourRepo;

        //sets up the ArmourController to use a repository for armours, storing it as _clanRepo. (signature)
        public ArmourController(IArmourRepository repo)
        {
            this._armourRepo = repo;
        }

        //Method that brings all the armours.
        //IEnumerable means that the GetAll() is returning a list of Armour objects that can be loop through.
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public IEnumerable<Armour> GetAll()
        {
            var result = _armourRepo.GetAll();
            return result;

        }

        //gets the armours by their id.
        [HttpGet("{id}")]
        public ActionResult<Armour> GetById(int id)
        {
            //it checks if the provided id exists, if yes then it finds it if not, returns a NotFound error.
            var clan = _armourRepo.GetById(id);
            if (clan == null)
            {
                return NotFound();
            }
            return clan;
        }


        //Creating a armour by passing an Armour object to the _armourRepo.Create() method.
        [HttpPost]
        public void Create(Armour armour)
        {
            _armourRepo.Create(armour);
        }

        //checks if the provided id exists, if yes then it updates the armour, if not then it gives an error
        [HttpPut("{id}")]
        public ActionResult<Armour> Update(int id, Armour armour)
        {
            if (id != armour.ArmourId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingArmour = _armourRepo.GetById(id);
            if (existingArmour == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            armour.ArmourId = id;

            _armourRepo.Update(armour);
            return Ok(armour);
        }


        //a method that deletes. it checks if the provided id exists, if yes, then deletes it. if not then
        //returns false
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Looks for the armour object from the database using the provided ID
            Armour armourToDelete = _armourRepo.GetAll().FirstOrDefault(c => c.ArmourId == id);

            if (armourToDelete == null)
            {
                // Return false if the provided id doesnt exist
                return false;
            }

            // Calls the Delete method in repository to delete the armour object
            return _armourRepo.Delete(armourToDelete);
        }
    }
}
