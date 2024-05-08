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
    public class SamuraiRepo : ISamuraiRepository
    {
        //we create this property so we can use it many times in each method,
        //instead of creating it many times in others.
        private readonly Dbcontext context;

        //this is dependency injection, 
        public SamuraiRepo(Dbcontext data)
        {
            //context cannot be called outside of the scope. so, we are calling the global one and assigning it to global. so we can use it out of the scope as well.
            this.context = data;
        }

       //Access Modifier: void er en type, der kommer ikke noget retur når man vælger at bruge void
       //if its boolean, there is a return
       //inside the parantese we always write variables
       //worst method is Lambda
        public Samurai Create(Samurai samurai)
        {

            //context is our Database
            context.Samurai.Add(samurai);
            context.SaveChanges();
            return samurai;

        }

        public List<Samurai> GetAll()
        {
            return context.Samurai.Include(s => s.Clan)
                .Include (s => s.Weapon)
                .Include (s=> s.War)
                .Include (s=> s.Armour)
                .Include(s=> s.Horse)
                .ToList();

        }



        public Samurai GetById(int id)  
        {
            return context.Samurai.FirstOrDefault(s => s.SamuraiId == id);
        }


        public bool Delete(Samurai samurai)
        {
            try
            {
                context.Samurai.Remove(samurai);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }

        }


        public Samurai Update(Samurai samurai)
        {
            var existingSamurai= context.Samurai.Find(samurai.SamuraiId);
            if (existingSamurai == null)
            {
                throw new ArgumentException("Samurai not found");

            }

            context.Entry(existingSamurai).CurrentValues.SetValues(samurai);

            context.SaveChanges();
            return existingSamurai;
        }

        public void CreateSamuraiWithLists(Samurai samurai)
        {
            //Samurai samTheGoodGuy = new Samurai { SamuraiId = 0, SamuraiName = "bandit", Description = "blabla", Age = 167 };
            Samurai sam = new Samurai()
            {
                SamuraiName = samurai.SamuraiName,
                Description = samurai.Description,
                Age = samurai.Age
            };
            context.Samurai.Add(sam);
            foreach (Horse horse in samurai.Horse)
            {
                var result = context.Horse.Find(horse.HorseId);
                if (result != null)
                {
                    sam.Horse.Add(result);
                }
            }
            context.SaveChanges();
            foreach (Armour armour in samurai.Armour)
            {
                var result = context.Armour.Find(armour.ArmourId);
                if (result != null)
                {
                    sam.Armour.Add(result);
                }
            }
            context.SaveChanges();
            foreach (War war in samurai.War)
            {
                var result = context.War.Find(war.WarId);
                if (result != null)
                {
                    sam.War.Add(result);
                }
            }
            context.SaveChanges();
            foreach (Weapon weapon in samurai.Weapon)
            {
                var result = context.Weapon.Find(weapon.WeaponId);
                if (result != null)
                {
                    sam.Weapon.Add(result);
                }
            }
            context.SaveChanges();
        }

    }

}
