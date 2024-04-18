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
    public class HorseRepo : IHorseRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public HorseRepo(Dbcontext data)
        {
            this.context = data;
        }

        //Access Modifier: void er en type, der kommer ikke noget retur når man vælger at bruge void
        //if its boolean, there is a return
        //inside the parantese we always write variables
        //worst method is Lambda
        public Horse Create(Horse horse)
        {
            //context is our Database
            context.Horse.Add(horse);
            context.SaveChanges();
            return horse;

        }

        public List<Horse> GetAll()
        {
            return context.Horse.ToList();
        }


        public Horse GetById(int id)
        {
            return context.Horse.FirstOrDefault(h => h.HorseId == id);
        }


        public bool Delete(Horse horse)
        {
            try
            {
                context.Horse.Remove(horse);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }

        }


        public Horse Update(Horse horse)
        {
            var existingHorse = context.Horse.Find(horse.HorseId);
            if (existingHorse == null)
            {
                throw new ArgumentException("Horse not found");

            }

            context.Entry(existingHorse).CurrentValues.SetValues(horse);

            context.SaveChanges();
            return existingHorse;
        }


    }

}
