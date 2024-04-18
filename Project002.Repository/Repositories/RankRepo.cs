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
    public class RankRepo : IRankRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public RankRepo(Dbcontext data)
        {
            this.context = data;
        }

        //Access Modifier: void er en type, der kommer ikke noget retur når man vælger at bruge void
        //if its boolean, there is a return
        //inside the parantese we always write variables
        //worst method is Lambda
        public Rank Create(Rank rank)
        {
            //context is our Database
            context.Rank.Add(rank);
            context.SaveChanges();
            return rank;

        }

        public List<Rank> GetAll()
        {
            return context.Rank.ToList();
        }


        public Rank GetById(int id)
        {
            return context.Rank.FirstOrDefault(s => s.RankId == id);
        }


        public bool Delete(Rank rank)
        {
            try
            {
                context.Rank.Remove(rank);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }

        }


        public Rank Update(Rank rank)
        {
            var existingRank = context.Rank.Find(rank.RankId);
            if (existingRank == null)
            {
                throw new ArgumentException("Rank not found");

            }

            context.Entry(existingRank).CurrentValues.SetValues(rank);

            context.SaveChanges();
            return existingRank;
        }


    }

}
