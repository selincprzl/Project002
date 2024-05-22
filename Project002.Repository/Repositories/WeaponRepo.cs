using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class WeaponRepo : IWeaponRepository
    {
        public readonly Dbcontext context;

        // Constructor to initialize the WeaponRepo with a database context
        public WeaponRepo(Dbcontext data)
        {
            this.context = data;
        }

        // Method to retrieve all Weapon records from the database
        public List<Weapon> GetAll()
        {
            // Retrieve all Weapon objects from the database and convert them to a list
            return context.Weapon.ToList();
        }





    }
}
