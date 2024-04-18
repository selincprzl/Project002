using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IArmourRepository
    {
        Armour Create(Armour armour);
        List<Armour> GetAll();
        Armour GetById(int id);

        bool Delete(Armour armour);

        Armour Update(Armour armour);

    }
}
