using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmourController : ControllerBase
    {
        private readonly IArmourRepository _armourRepo;

        public ArmourController(IArmourRepository repo)
        {
            this._armourRepo = repo;
        }

        // GET: api/<Country>
        [HttpGet]
        public IEnumerable<Armour> GetAll()
        {
            var result = _armourRepo.GetAll();
            return result;

        }

        // POST api/<Country>
        [HttpPost]
        public void Create(Armour clan)
        {
            _armourRepo.Create(clan);
        }

        [HttpPut("{id}")]
        public ActionResult<Armour> Update(int id, Armour clan)
        {
            if (id != clan.ArmourId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingArmour = _armourRepo.GetById(id);
            if (existingArmour == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            clan.ArmourId = id;

            _armourRepo.Update(clan);
            return Ok(clan);
        }


        [HttpGet("{id}")]
        public ActionResult<Armour> GetById(int id)
        {
            var clan = _armourRepo.GetById(id);
            if (clan == null)
            {
                return NotFound();
            }
            return clan;
        }


        // DELETE api/<Country>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            Armour countryToDelete = _armourRepo.GetAll().FirstOrDefault(c => c.ArmourId == id);

            if (countryToDelete == null)
            {
                return false;
            }

            return _armourRepo.Delete(countryToDelete);
        }
    }
}
