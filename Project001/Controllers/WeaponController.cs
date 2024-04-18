using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Migrations;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class WeaponController : ControllerBase

    {
        // This is like a special function that sets up the controller.
        //It takes something called a "repository" as input. A repository helps us interact with our database.
        private readonly IWeaponRepository _weaponRepo;
        

        public WeaponController (IWeaponRepository repo)
        {
            this._weaponRepo = repo;
        }

        // GET: api/<WeaponController>
        //when someone wants to "get" information, they should use this method.
        [HttpGet]
        public IEnumerable<Weapon> GetAll()

        {
            var result=_weaponRepo.GetAll();
            return result;
        }

        //When someone wants to "post" or add something, they should use this method.
        [HttpPost]
        public void Create(Weapon weapon)
        {
            _weaponRepo.Create(weapon);
        }

        // DELETE api/<WeaponController>/5
        [HttpDelete("{id}")]

        //This function finds a weapon by its ID and deletes it from the database.
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Weapon weaponToDelete = _weaponRepo.GetAll().FirstOrDefault(w => w.WeaponId == id);

            if (weaponToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _weaponRepo.Delete(weaponToDelete);
        }


        [HttpPut("{id}")]
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


        [HttpGet("{id}")]
        public ActionResult<Weapon> GetById(int id)
        {
            var weapon = _weaponRepo.GetById(id);
            if (weapon == null)
            {
                return NotFound();
            }
            return weapon;
        }



        
    }
}
