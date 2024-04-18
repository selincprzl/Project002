using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController] //this we will take in another afsnit
    public class ClothingController : ControllerBase
    {
        private readonly IClothingRepository _clothingRepo;

        //Constractor: is a special method in a class. It has the same name as the class name
        //can be used to assign arguments to fields when creating an object.


        //this is a constractor / and constractor is always called - not defined
        public ClothingController(IClothingRepository repo)
        {
            this._clothingRepo = repo;
        }



        // GET: api/<ClothingController>
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public IEnumerable<Clothing> GetAll()

        {
            var result = _clothingRepo.GetAll();
            return result;
        }



        // POST api/<ClothingController>
        //Signature- Prototype / method
        [HttpPost]
        public void Create(Clothing clothing)
        {
            _clothingRepo.Create(clothing);

        }

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

        // DELETE api/<ClothingController>/5
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
