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
    public class ClanRepo : IClanRepository
    {
        private readonly Dbcontext context;

        public ClanRepo(Dbcontext data)
        {
            this.context = data;
        }

        public Clan Create(Clan clan)
        {
            context.Clan.Add(clan);
            context.SaveChanges();
            return clan;
        }

        public List<Clan> GetAll()
        {
            return context.Clan.ToList();
        }

        public Clan GetById(int id) {
            return context.Clan.FirstOrDefault(c => c.ClanId == id);
        }

        public bool Delete(Clan clan)
        {
            try
            {
                context.Clan.Remove(clan);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Clan Update(Clan clan)
        {
            var existingClan = context.Clan.Find(clan.ClanId);
            if (existingClan == null)
            {
                throw new ArgumentException("Country not found");

            }

            context.Entry(existingClan).CurrentValues.SetValues(clan);

            context.SaveChanges();
            return existingClan;
        }

    }
}
    