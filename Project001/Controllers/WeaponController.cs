using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController]

    
    public class WeaponController : ControllerBase

    {
        //_weaponRepo is like a container that holds informations about weapons.
        //readonly means it cannot be changed once its set.
        private readonly IWeaponRepository _weaponRepo;
        
        //sets up the WeaponController to use a repository for weapons, storing it as _weaponRepo.(signature)

        public WeaponController (IWeaponRepository repo)
        {
            this._weaponRepo = repo;
        }

        //method that brings all the weapons
        //IEnumerable means that the GetAll() is returning a list of Weapon objects that can be loop through.
        [HttpGet]//This is a DataAnnotion / Attribute / its a rule. defines what method is able to do.

        public IEnumerable<Weapon> GetAll()

        {
            var result=_weaponRepo.GetAll();
            return result;
        }

        //gets the weapon by their id.
        [HttpGet("{id}")]
        public ActionResult<Weapon> GetById(int id)
        {
            //it checks if the provided id exists, if yes then it finds it if not, returns a NotFound error.
            var weapon = _weaponRepo.GetById(id);
            if (weapon == null)
            {
                return NotFound();
            }
            return weapon;
        }

        //creating a weapon by passing an weapon object to the _weaponRepo.Create()method. (signature)
        [HttpPost]
        public void Create(Weapon weapon)
        {
            _weaponRepo.Create(weapon);
        }

        [HttpPut("{id}")]
        //checks if the provided id exists, if yes then it updates the armour, if not then it gives an error
        public ActionResult<Weapon> Update(int id, Weapon weapon)
        {
            if (id != weapon.WeaponId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingWeapon = _weaponRepo.GetById(id);
            if (existingWeapon == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            weapon.WeaponId = id;

            _weaponRepo.Update(weapon);
            return Ok(weapon);
        }

        //a method that deletes. it checks if the provided id exists, if yes, then deletes it. if not then
        //returns false
        
        [HttpDelete("{id}")]

        public bool Delete(int id)

        {
            //looks for the weapon object from the database using the provided ID
            Weapon weaponToDelete = _weaponRepo.GetAll().FirstOrDefault(w => w.WeaponId == id);

            if (weaponToDelete == null)
            {
                //return false if the provided id doesnt exist
                return false;
            }

            // Calls the Delete method in repository to delete the armour object
            return _weaponRepo.Delete(weaponToDelete);
        }


  


 



        
    }
}
