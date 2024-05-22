using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IWarRepository // Interface to define methods for interacting with war data
    {
        War Create(War war); // Method signature to create a new war

        List<War> GetAll(); // Method signature to retrieve all war data

        War GetById(int id); // Method signature to retrieve a war by ID

        bool Delete(War war); // Method signature to delete a war

        War Update(War war); // Method signature to update a war
    }

}
