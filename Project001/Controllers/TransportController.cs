using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _transportRepo;

        public TransportController(ITransportRepository repo)
        {
            this._transportRepo = repo;
        }

        // GET: api/<Transport>
        [HttpGet]
        public IEnumerable<Transport> GetAll()
        {
            var result = _transportRepo.GetAll();
            return result;

        }

        // POST api/<Transport>
        [HttpPost]
        public void Create(Transport transport)
        {
            _transportRepo.Create(transport);
        }

        [HttpPut("{id}")]
        public ActionResult<Transport> Update(int id, Transport transport)
        {
            if (id != transport.TransportId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingTransport = _transportRepo.GetById(id);
            if (existingTransport == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            transport.TransportId = id;

            _transportRepo.Update(transport);
            return Ok(transport);
        }


        [HttpGet("{id}")]
        public ActionResult<Transport> GetById(int id)
        {
            var transport = _transportRepo.GetById(id);
            if (transport == null)
            {
                return NotFound();
            }
            return transport;
        }


        // DELETE api/<Transport>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            Transport transportToDelete = _transportRepo.GetAll().FirstOrDefault(h => h.TransportId == id);

            if (transportToDelete == null)
            {
                return false;
            }

            return _transportRepo.Delete(transportToDelete);
        }
    }
}
