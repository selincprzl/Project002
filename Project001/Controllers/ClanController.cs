using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly IClanRepository _clanRepo;

        public ClanController (IClanRepository repo)
        {
            this._clanRepo = repo;
        }

        // GET: api/<Country>
        [HttpGet]
        public IEnumerable<Clan> GetAll()
        {
            var result = _clanRepo.GetAll();
            return result;

        }
        
        // POST api/<Country>
        [HttpPost]
        public void Create (Clan clan)
        {
            _clanRepo.Create(clan);
        }

        [HttpPut("{id}")]
        public ActionResult<Clan> Update(int id, Clan clan)
        {
            if (id != clan.ClanId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingClan = _clanRepo.GetById(id);
            if (existingClan == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            clan.ClanId = id;

            _clanRepo.Update(clan);
            return Ok(clan);
        }


        [HttpGet("{id}")]
        public ActionResult<Clan> GetById(int id)
        {
            var clan = _clanRepo.GetById(id);
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

            Clan countryToDelete = _clanRepo.GetAll().FirstOrDefault(c=> c.ClanId == id);
            
            if(countryToDelete == null)
            {
                return false;
            }

            return _clanRepo.Delete(countryToDelete);
        }
    }
}
