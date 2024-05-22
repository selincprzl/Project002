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

        // Constructor to initialize the WarRepo with a database context
        public WarRepo(Dbcontext data)
        {
            this.context = data;
        }

        // Method to create a new War record in the database
        public War Create(War war)
        {
            // Add the provided War object to the database context
            context.War.Add(war);

            // Save changes to the database
            context.SaveChanges();

            // Return the newly created War object
            return war;
        }

        // Method to get all War records from the database
        public List<War> GetAll()
        {
            return context.War.ToList();
        }
   

        // Method to delete a War record from the database
        public bool Delete(War war)
        {
            try
            {
                // Remove the provided War object from the database context
                context.War.Remove(war);

                // Save changes to the database
                context.SaveChanges();

                // Indicate successful deletion 
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                // Indicate deletion failure 
                return false;
            }
        }
        public War GetById(int id)
        {
            return context.War.FirstOrDefault(w => w.WarId == id);
        }

        // Method to update an existing War record in the database
        public War Update(War war)
        {
            // Find the existing War object by its ID
            var existingWar = context.War.Find(war.WarId);

            // If the existing War object is not found, throw an exception
            if (existingWar == null)
            {
                throw new ArgumentException("War not found");
            }

            // Update the properties of the existing War object with the values from the provided War object
            context.Entry(existingWar).CurrentValues.SetValues(war);

            // Save changes to the database
            context.SaveChanges();

            // Return the updated War object
            return existingWar;
        }

    }
}
