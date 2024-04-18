using Project002.Repository.Interfaces;
using Project002.Repository.Migrations;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class WeaponRepo : IWeaponRepository
    {
        public readonly Dbcontext context;
        public WeaponRepo(Dbcontext data) {

            this.context = data;
        }

        public Weapon Create(Weapon weapon)
        {
            context.Weapon.Add(weapon);
            context.SaveChanges();
            return weapon;
        }

        public List<Weapon> GetAll()
        {
            return context.Weapon.ToList();
        }

        public Weapon GetById(int id)
        {
            return context.Weapon.FirstOrDefault(w => w.WeaponId == id);
        }


        public bool Delete(Weapon weapon)
        {
            try
            {
                context.Weapon.Remove(weapon);
                context.SaveChanges();
                return true; // Indicate successful deletion 
            }
            catch (Exception ex)
            {
                // Handle exception or log error 
                return false; // Indicate deletion failure 
            }
        }

        public Weapon Update(Weapon weapon)
        {
            var existingWeapon = context.Weapon.Find(weapon.WeaponId);
            if (existingWeapon == null)
            {
                throw new ArgumentException("Samurai not found");

            }

            context.Entry(existingWeapon).CurrentValues.SetValues(weapon);

            context.SaveChanges();
            return existingWeapon;
        }



    }
}
