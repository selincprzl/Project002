using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Migrations;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController] //this we will take in another afsnit
    public class WarController : ControllerBase
    {
        private readonly IWarRepository _warRepo;

        //this is a constractor / and constractor is always called - not defined
        public WarController(IWarRepository repo)
        {
            this._warRepo = repo;
        }

        // GET: api/<SamuraiController>
        [HttpGet]
        public IEnumerable<War> GetAll()

        {
            var result = _warRepo.GetAll();
            return result;
        }

        [HttpPost]
        public void Create(War war)
        {
            _warRepo.Create(war);

        }

        [HttpPut("{id}")]
        public ActionResult<War> Update(int id, War war)
        {
            if (id != war.WarId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingSamurai = _warRepo.GetById(id);
            if (existingSamurai == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            war.WarId = id;

            _warRepo.Update(war);
            return Ok(war);
        }


        [HttpGet("{id}")]
        public ActionResult<War> GetById(int id)
        {
            var war = _warRepo.GetById(id);
            if (war == null)
            {
                return NotFound();
            }
            return war;
        }

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            War warToDelete = _warRepo.GetAll().FirstOrDefault(w => w.WarId == id);

            if (warToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _warRepo.Delete(warToDelete);
        }
    }
}
