using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IHorseRepository
    {

        Horse Create(Horse horse);
        List<Horse> GetAll();
        Horse GetById(int id);
        bool Delete(Horse horse);

        Horse Update(Horse horse);
    }
}
