using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project002.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Project002.Repository.Interfaces;
using Project002.Repository.Migrations;

namespace Project002.Repository.Repositories
{
    public class ClothingRepo : IClothingRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public ClothingRepo(Dbcontext data)
        {
            this.context = data;
        }

        //Access Modifier: void er en type, der kommer ikke noget retur når man vælger at bruge void
        //if its boolean, there is a return
        //inside the parantese we always write variables
        //worst method is Lambda
        public Clothing Create(Clothing clothing)
        {
            //context is our Database
            context.Clothing.Add(clothing);
            context.SaveChanges();
            return clothing;

        }

        public List<Clothing> GetAll()
        {
            return context.Clothing.ToList();
        }


        public Clothing GetById(int id)
        {
            return context.Clothing.FirstOrDefault(c => c.ClothingId == id);
        }


        public bool Delete(Clothing clothing)
        {
            try
            {
                context.Clothing.Remove(clothing);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }

        }


        public Clothing Update(Clothing clothing)
        {
            var existingClothing = context.Clothing.Find(clothing.ClothingId);
            if (existingClothing == null)
            {
                throw new ArgumentException("Samurai not found");

            }
            context.Entry(existingClothing).CurrentValues.SetValues(clothing);

            context.SaveChanges();
            return existingClothing;
        }


    }

}
