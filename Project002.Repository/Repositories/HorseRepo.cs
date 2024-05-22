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

        public List<Horse> GetAll()
        {
            return context.Horse.ToList();
        }


    }

}
