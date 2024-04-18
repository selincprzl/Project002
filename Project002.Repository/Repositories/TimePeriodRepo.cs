using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class TimePeriodRepo : ITimePeriodRepository
    {

        private readonly Dbcontext context;
        public TimePeriodRepo(Dbcontext data)
        {
            this.context = data;

        }

        public TimePeriod Create(TimePeriod timePeriod)
        {
            //context is our Database
            context.TimePeriod.Add(timePeriod);
            context.SaveChanges();
            return timePeriod;

        }

        public List<TimePeriod> GetAll()
        {

            return context.TimePeriod.ToList();

        }

        public TimePeriod GetById(int id)
        {
            return context.TimePeriod.FirstOrDefault(w => w.TimePeriodId == id);
        }


        public bool Delete(TimePeriod timePeriod)
        {
            try
            {
                context.TimePeriod.Remove(timePeriod);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }
        }

        public TimePeriod Update(TimePeriod timePeriod)
        {
            var existingTimePeriod = context.TimePeriod.Find(timePeriod.TimePeriodId);
            if (existingTimePeriod == null)
            {
                throw new ArgumentException("TimePeriod not found");

            }

            context.Entry(existingTimePeriod).CurrentValues.SetValues(timePeriod);

            context.SaveChanges();
            return existingTimePeriod;
        }


    }
}
