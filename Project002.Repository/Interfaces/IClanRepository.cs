using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IClanRepository
    {
        Clan Create (Clan clan);
        List<Clan> GetAll ();
        Clan GetById(int id);

        bool Delete (Clan clan);

        Clan Update (Clan clan);  

    }
}
