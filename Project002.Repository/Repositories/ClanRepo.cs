using Humanizer;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class ClanRepo : IClanRepository
    {
        private readonly Dbcontext context; //we create this property so we can use it many times in each method,
        //instead of creating it many times in other methods.

        public ClanRepo(Dbcontext data)
        {
            //context cannot be called outside of the scope. so, we are calling the global one and assigning it to global. so we can use it out of the scope as well.
            this.context = data;
        }

        public List<Clan> GetAll() // Method to retrieve all clan data
        {

            return context.Clan.ToList(); // Returning a list of all armour from the database context
        }

    }
}
