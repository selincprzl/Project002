using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project002.Repository.DTOs;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController] //this we will take in another afsnit
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository _samuraiRepo;
        IMapper _mapper;

        //Constractor: is a special method in a class. It has the same name as the class name
        //can be used to assign arguments to fields when creating an object.


        //this is a constractor / and constractor is always called - not defined
        public SamuraiController(ISamuraiRepository repo, IMapper mapper) {
            this._samuraiRepo = repo;
            this._mapper = mapper;
        }
        


        // GET: api/<SamuraiController>
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public ActionResult GetAll()
          
        {
            var items = _mapper.Map<List<SamuraiDTO>>(_samuraiRepo.GetAll());

            return Ok(items);
        }



        // POST api/<SamuraiController>
        //Signature- Prototype / method
        [HttpPost]
        public void Create(Samurai samurai)
        {
            _samuraiRepo.Create(samurai);
            
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
    }
}
