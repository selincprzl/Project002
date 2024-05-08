using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")] //our URL
    [ApiController] 
    public class WarController : ControllerBase
    {
        private readonly IWarRepository _warRepo;

        public WarController(IWarRepository repo)
        {
            this._warRepo = repo;
        }

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

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            War warToDelete = _warRepo.GetAll().FirstOrDefault(w => w.WarId == id);

            if (warToDelete == null)
            {
                return false;
            }

            return _warRepo.Delete(warToDelete);
        }
    }
}
