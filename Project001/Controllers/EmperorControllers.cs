using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmperorController : ControllerBase
    {
        private readonly IEmperorRepository _emperorRepo;

        public EmperorController(IEmperorRepository repo)
        {
            this._emperorRepo = repo;
        }

        // GET: api/<Emperor>
        [HttpGet]
        public IEnumerable<Emperor> GetAll()
        {
            var result = _emperorRepo.GetAll();
            return result;

        }

        // POST api/<Emperor>
        [HttpPost]
        public void Create(Emperor emperor)
        {
            _emperorRepo.Create(emperor);
        }

        [HttpPut("{id}")]
        public ActionResult<Emperor> Update(int id, Emperor emperor)
        {
            if (id != emperor.EmperorId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingEmperor = _emperorRepo.GetById(id);
            if (existingEmperor == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            emperor.EmperorId = id;

            _emperorRepo.Update(emperor);
            return Ok(emperor);
        }


        [HttpGet("{id}")]
        public ActionResult<Emperor> GetById(int id)
        {
            var emperor = _emperorRepo.GetById(id);
            if (emperor == null)
            {
                return NotFound();
            }
            return emperor;
        }


        // DELETE api/<Emperor>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            Emperor countryToDelete = _emperorRepo.GetAll().FirstOrDefault(c => c.EmperorId == id);

            if (countryToDelete == null)
            {
                return false;
            }

            return _emperorRepo.Delete(countryToDelete);
        }
    }
}
