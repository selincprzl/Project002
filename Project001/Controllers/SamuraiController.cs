using Microsoft.AspNetCore.Mvc;
using Project002.Repository;
using Project002.Repository.Models;
using Project002.Repository.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")] // our URL
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        //_samuraiRepo is like a container that holds informations about samurai
        //readonly means, it cannot be changed once its set
        private readonly ISamuraiRepository _samuraiRepo;

        //sets up SamuraiController to use a repository for samurai, storing it as _samuraiRepo.(signature=
        public SamuraiController(ISamuraiRepository samuraiRepo)
        {
            _samuraiRepo = samuraiRepo;
        }


        //method that bring all the Samurais.
        //IEnumerable means that GetAll() is returning a list of Samurai objects that can be looped through.
       //DataAnnotion / Attribute / its a rule. defines what method is able to do or not.
        [HttpGet]
        public IEnumerable<Samurai> GetAll()
        {

            var result = _samuraiRepo.GetAll();
            return result;
        }

        //gets the samurai by its id
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

        [HttpPost("Wednesday")]
        public void CreateSamuraiWithLists(Samurai samurai)
        {
            _samuraiRepo.CreateSamuraiWithLists(samurai);
        }


        //Creates a samurai by passin an Samurai object to the _samuraiRepo.Create() method.

        [HttpPost("createMore")]
        public void CreateModels(Samurai samurai)
        {

        }


        [HttpPost]
        public ActionResult Create(Samurai samurai)
        {
            var sam = _samuraiRepo.Create(samurai);
            return Ok(sam);
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

            samurai.SamuraiId = id;

            _samuraiRepo.Update(samurai);
            return Ok(samurai);
        }





        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Samurai samuraiToDelete = _samuraiRepo.GetAll().FirstOrDefault(s => s.SamuraiId == id);

            if (samuraiToDelete == null)
            {
                return false;
            }

            return _samuraiRepo.Delete(samuraiToDelete);
        }

    }
}