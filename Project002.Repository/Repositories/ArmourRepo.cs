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
    public class ArmourRepo : IArmourRepository
    {
        private readonly Dbcontext context;

        public ArmourRepo(Dbcontext data)
        {
            this.context = data;
        }

        public Armour Create(Armour armour)
        {
            context.Armour.Add(armour);
            context.SaveChanges();
            return armour;
        }

        public List<Armour> GetAll()
        {
            return context.Armour.ToList();
        }

        public Armour GetById(int id)
        {
            return context.Armour.FirstOrDefault(c => c.ArmourId == id);
        }

        public bool Delete(Armour armour)
        {
            try
            {
                context.Armour.Remove(armour);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Armour Update(Armour armour)
        {
            var existingArmour = context.Armour.Find(armour.ArmourId);
            if (existingArmour == null)
            {
                throw new ArgumentException("Clan not found");

            }

            context.Entry(existingArmour).CurrentValues.SetValues(armour);

            context.SaveChanges();
            return existingArmour;
        }

    }
}
