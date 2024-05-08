using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;


namespace Project001.Controllers
{
    [Route("api/[controller]")] //our url
    [ApiController]
    public class FrontPageController : ControllerBase

    {   //_frontRepo is like a container that holds informations about fronts
        //readonly means, it cannot be changed once its set.
        private readonly IFrontPageRepository _frontPageRepo;

        //sets up the FrontController to use a repository for fronts, storing it as _clanRepo. (signature)
        public FrontPageController(IFrontPageRepository repo)
        {
            this._frontPageRepo = repo;
        }

        //Method that brings all the fronts.
        //IEnumerable means that the GetAll() is returning a list of Front objects that can be loop through.
        [HttpGet] //this is a DataAnnotation / Attribute /its a rule. defines what method is able to do or a class
        public IEnumerable<FrontPage> GetAll()
        {
            var result = _frontPageRepo.GetAll();
            return result;

        }

       
    }
}
