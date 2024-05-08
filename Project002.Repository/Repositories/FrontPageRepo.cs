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
    public class FrontRepo : IFrontPageRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public FrontRepo(Dbcontext data)
        {
            //context cannot be called outside of the scope. so, we are calling the global one and assigning it to global. so we can use it out of the scope as well.
            this.context = data;
        }

       

        public List<FrontPage> GetAll()
        {

            return context.FrontPage.ToList();
            
            
        }



     
            }

        }


      
