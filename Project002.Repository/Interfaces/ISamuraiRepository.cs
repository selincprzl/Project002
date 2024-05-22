using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface ISamuraiRepository // Interface to define methods for interacting with samurai data
    {
        List<Samurai> GetAll(); // Method signature to retrieve all samurai data

        Samurai Create(Samurai samurai); // Method signature to create a new samurai
    }


}
