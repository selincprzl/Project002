using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IRankRepository _historyRepo;

        public HistoryController(IRankRepository repo)
        {
            this._historyRepo = repo;
        }

        // GET: api/<History>
        [HttpGet]
        public IEnumerable<History> GetAll()
        {
            var result = _historyRepo.GetAll();
            return result;

        }

        // POST api/<History>
        [HttpPost]
        public void Create(History history)
        {
            _historyRepo.Create(history);
        }

        [HttpPut("{id}")]
        public ActionResult<History> Update(int id, History history)
        {
            if (id != history.HistoryId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingHistory = _historyRepo.GetById(id);
            if (existingHistory == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            history.HistoryId = id;

            _historyRepo.Update(history);
            return Ok(history);
        }


        [HttpGet("{id}")]
        public ActionResult<History> GetById(int id)
        {
            var history = _historyRepo.GetById(id);
            if (history == null)
            {
                return NotFound();
            }
            return history;
        }


        // DELETE api/<History>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            History historyToDelete = _historyRepo.GetAll().FirstOrDefault(h => h.HistoryId == id);

            if (historyToDelete == null)
            {
                return false;
            }

            return _historyRepo.Delete(historyToDelete);
        }
    }
}
