using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project002.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Project002.Repository.Interfaces;

namespace Project002.Repository.Repositories
{
    public class SamuraiRepo : ISamuraiRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public SamuraiRepo(Dbcontext data)
        {
            //context cannot be called outside of the scope. so, we are calling the global one and assigning it to global. so we can use it out of the scope as well.
            this.context = data;
        }


        public Samurai Create(Samurai samurai)
        {
            // Add the provided Samurai object to the database context
            context.Samurai.Add(samurai);

            // Save changes to the database
            context.SaveChanges();

            // Return the Samurai object that was just created
            return samurai;
        }

        public List<Samurai> GetAll()
        {
            // Retrieve all Samurai objects from the database
            return context.Samurai
                //Include Weapon, Armour, Horse objects in the query results.
                .Include(s => s.Weapon)
                .Include(s => s.Armour)
                .Include(s => s.Horse)

                // Convert the query results to a list
                .ToList();
        }





    }
}