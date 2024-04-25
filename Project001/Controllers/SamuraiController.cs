using Microsoft.AspNetCore.Mvc;
using Project002.Repository;
using Project002.Repository.Models;
using Project002.Repository.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")] // our URL
    [ApiController] //this we will take in another afsnit
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository _samuraiRepo;

        public SamuraiController(ISamuraiRepository samuraiRepo)
        {
            _samuraiRepo = samuraiRepo;
        }




        // GET: api/<SamuraiController>
        //This is a DataAnnotation / Attribute
        [HttpGet]
        public IEnumerable<Samurai> GetAll()
        {
            //If i want too DEBUG!

            var result = _samuraiRepo.GetAll();
            return result;
        }


        //CREATE
        [HttpPost]
        public void Create(Samurai samurai)
        {
            _samuraiRepo.Create(samurai);
        }



        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Samurai samuraiToDelete = _samuraiRepo.GetAll().FirstOrDefault(s => s.SamuraiId == id);

            if (samuraiToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _samuraiRepo.Delete(samuraiToDelete);
        }
        [HttpPut("{id}")]
        public ActionResult<Samurai> Update(int id, Samurai samurai)
        {
            if (id != samurai.SamuraiId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingSamurai = _samuraiRepo.GetById(id);
            if (existingSamurai == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            samurai.SamuraiId = id;

            _samuraiRepo.Update(samurai);
            return Ok(samurai);
        }


        [HttpGet("{id}")]
        public ActionResult<Samurai> GetById(int id)
        {
            var samurai = _samuraiRepo.GetById(id);
            if (samurai == null)
            {
                return NotFound();
            }
            return samurai;
        }

    }
}