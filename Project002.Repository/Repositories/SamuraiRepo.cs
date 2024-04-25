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
            this.context = data;
        }

       //Access Modifier: void er en type, der kommer ikke noget retur når man vælger at bruge void
       //if its boolean, there is a return
       //inside the parantese we always write variables
       //worst method is Lambda
        public Samurai Create(Samurai samurai)
        {

            //context is our Database
            context.Samurai.Add(samurai);
            context.SaveChanges();
            return samurai;

        }

        public ICollection<Samurai> GetAll()
        {
            return context.Samurai.ToList();
        }


        public Samurai GetById(int id)
        {
            return context.Samurai.FirstOrDefault(s => s.SamuraiId == id);
        }


        public bool Delete(Samurai samurai)
        {
            try
            {
                context.Samurai.Remove(samurai);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }

        }


        public Samurai Update(Samurai samurai)
        {
            var existingSamurai= context.Samurai.Find(samurai.SamuraiId);
            if (existingSamurai == null)
            {
                throw new ArgumentException("Samurai not found");

            }

            context.Entry(existingSamurai).CurrentValues.SetValues(samurai);

            context.SaveChanges();
            return existingSamurai;
        }
        

    }

}
