using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimePeriodController : ControllerBase
    {
        private readonly ITimePeriodRepository _timePeriodRepo;

        public TimePeriodController(ITimePeriodRepository repo)
        {
            this._timePeriodRepo = repo;
        }

        // GET: api/<Country>
        [HttpGet]
        public IEnumerable<TimePeriod> GetAll()
        {
            var result = _timePeriodRepo.GetAll();
            return result;

        }

        // POST api/<Country>
        [HttpPost]
        public void Create(TimePeriod timePeriod)
        {
            _timePeriodRepo.Create(timePeriod);
        }

        [HttpPut("{id}")]
        public ActionResult<TimePeriod> Update(int id, TimePeriod timePeriod)
        {
            if (id != timePeriod.TimePeriodId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingTimePeriod = _timePeriodRepo.GetById(id);
            if (existingTimePeriod == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            timePeriod.TimePeriodId = id;

            _timePeriodRepo.Update(timePeriod);
            return Ok(timePeriod);
        }


        [HttpGet("{id}")]
        public ActionResult<TimePeriod> GetById(int id)
        {
            var timePeriod = _timePeriodRepo.GetById(id);
            if (timePeriod == null)
            {
                return NotFound();
            }
            return timePeriod;
        }


        // DELETE api/<Country>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            TimePeriod countryToDelete = _timePeriodRepo.GetAll().FirstOrDefault(c => c.TimePeriodId == id);

            if (countryToDelete == null)
            {
                return false;
            }

            return _timePeriodRepo.Delete(countryToDelete);
        }
    }
}
