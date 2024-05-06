using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController] 
    public class ClothingController : ControllerBase
    {
        //_clothingRepo is like a container that holds information about clothing
        //readonly means, it cannot be changed once its set.
        private readonly IClothingRepository _clothingRepo;

        //sets up the ClanController to use a repository for clans, storing it as
        //_clothingRepo. (signature)
        public ClothingController(IClothingRepository repo)
        {
            this._clothingRepo = repo;
        }



        //Method that brings all the Clothing
        //IEnumerable means that the GetAll() is returning a list of Clothing
        //objects that can be looped through.
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public IEnumerable<Clothing> GetAll()

        {
            var result = _clothingRepo.GetAll();
            return result;
        }

        //gets clothing by their id.
        [HttpGet("{id}")]
        public ActionResult<Clothing> GetById(int id)
        {
            var clothes = _clothingRepo.GetById(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return clothes;
        }

        //Creating clothing by passing a Clothing object to the _clothingRepo.Create() method.
        [HttpPost]
        public void Create(Clothing clothing)
        {
            _clothingRepo.Create(clothing);

        }

        //checks if provided id exists, if yes then it updates the clothing. if not, then it gives notfound error.
        [HttpPut("{id}")]
        public ActionResult<Clothing> Update(int id, Clothing clothing)
        {
            if (id != clothing.ClothingId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingClothes = _clothingRepo.GetById(id);
            if (existingClothes == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            clothing.ClothingId = id;

            _clothingRepo.Update(clothing);
            return Ok(clothing);
        }



        //method that deletes. it checks if the provided id exists, if yes then it deletes it
        //if not, then it returns false.
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Clothing object from the database using the provided ID
            Clothing clothingToDelete = _clothingRepo.GetAll().FirstOrDefault(c => c.ClothingId == id);

            if (clothingToDelete == null)
            {
                // Return false or handle the case where the Clothing object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Clothing object
            return _clothingRepo.Delete(clothingToDelete);
        }
    }
}
