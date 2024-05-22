using Project002.Repository.Interfaces; 
using Project002.Repository.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class ArmourRepo : IArmourRepository // Class implementing the IArmourRepository interface
    {
        private readonly Dbcontext context; // Private variable to hold the database context

        public ArmourRepo(Dbcontext data) // Constructor to initialize the ArmourRepo with a database context
        {
            this.context = data; // Assigning the database context provided to the private variable
        }

        public List<Armour> GetAll() // Method to retrieve all armour data
        {
            return context.Armour.ToList(); // Returning a list of all armour from the database context
        }
    }
}
