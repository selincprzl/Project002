using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly IHorseRepository _horseRepo;

        public HorseController(IHorseRepository repo)
        {
            this._horseRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Horse> GetAll()
        {
            var result = _horseRepo.GetAll();
            return result;

        }

        [HttpPost]
        public void Create(Horse horse)
        {
            _horseRepo.Create(horse);
        }

        [HttpPut("{id}")]
        public ActionResult<Horse> Update(int id, Horse horse)
        {
            if (id != horse.HorseId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingHorse = _horseRepo.GetById(id);
            if (existingHorse == null)
            {
                return NotFound();
            }

            horse.HorseId = id;

            _horseRepo.Update(horse);
            return Ok(horse);
        }


        [HttpGet("{id}")]
        public ActionResult<Horse> GetById(int id)
        {
            var horse = _horseRepo.GetById(id);
            if (horse == null)
            {
                return NotFound();
            }
            return horse;
        }


        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            Horse horseToDelete = _horseRepo.GetAll().FirstOrDefault(h => h.HorseId == id);

            if (horseToDelete == null)
            {
                return false;
            }

            return _horseRepo.Delete(horseToDelete);
        }
    }
}
