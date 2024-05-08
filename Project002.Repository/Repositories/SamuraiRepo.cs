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
                .Include(s => s.Weapon)
                .Include(s => s.Armour)
                .Include(s => s.Horse)
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
            var existingSamurai = context.Samurai.Find(samurai.SamuraiId);
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

            Samurai sam = new Samurai()
            {
                SamuraiName = samurai.SamuraiName,
                Description = samurai.Description,
                Age = samurai.Age,
            };
            // Add Samurai to context
            context.Samurai.Add(samurai);

            if(samurai.Clan != null)
            {
                foreach(Clan c in samurai.Clan.ToList())
                {
                    sam.Clan.Add(c);
                }
            }

            // Add Horse to Samurai
            foreach (Horse horse in samurai.Horse.ToList())
            {
                    sam.Horse.Add(horse);
            }

            // Add Weapons to Samurai
            //foreach (Weapon weapon in samurai.Weapon.ToList())
            //{
            //    var result = context.Weapon.Find(weapon.WeaponId);
            //    if (result != null)
            //    {
            //        sam.Weapon.Add(result);
            //    }
            //}

            //// Add Armor to Samurai
            //foreach (Armour armor in samurai.Armour.ToList())
            //{
            //    var result = context.Armour.Find(armor.ArmourId);
            //    if (result != null)
            //    {
            //        sam.Armour.Add(result);
            //    }
            //}

            //foreach (War war in samurai.War.ToList())
            //{
            //    var result = context.War.Find(war.WarId);
            //    if (result != null)
            //    {
            //            sam.War.Add(result);
            //    }
            //}

            //Add Clan to K
            //sam.Clan.A

            //var clanResult = context.Clan.Find(samurai.Clan.ClanId);
            //if (clanResult != null)
            //{
            //    sam.Clan.Add
            //}

            // Save changes to the context
            context.SaveChanges();
        }


    }
}