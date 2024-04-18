using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IRankRepository
    {
        Rank Create(Rank rank);
        List<Rank> GetAll();
        Rank GetById(int id);

        bool Delete(Rank rank);

        Rank Update(Rank rank);
    }
}
