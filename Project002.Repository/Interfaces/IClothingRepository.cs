using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IClothingRepository
    {
        Clothing Create(Clothing clothing);
        List<Clothing> GetAll();
        Clothing GetById(int id);
        bool Delete(Clothing clothing);

        Clothing Update(Clothing clothing);

    }

}
