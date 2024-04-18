using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class WarRepo : IWarRepository
    {

        private readonly Dbcontext context;
        public WarRepo(Dbcontext data) { 
            this.context = data;
        
        }

        public War Create(War war)
        {
            //context is our Database
            context.War.Add(war);
            context.SaveChanges();
            return war;

        }

        public List<War> GetAll() {

            return context.War.ToList();

        }

        public War GetById(int id)
        {
            return context.War.FirstOrDefault(w => w.WarId == id);
        }


        public bool Delete(War war)
        {
            try
            {
                context.War.Remove(war);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }
        }

        public War Update(War war)
        {
            var existingWar = context.War.Find(war.WarId);
            if (existingWar == null)
            {
                throw new ArgumentException("War not found");

            }

            context.Entry(existingWar).CurrentValues.SetValues(war);

            context.SaveChanges();
            return existingWar;
        }


    }
}
