using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IWarRepository
    {
        War Create(War war);
        List<War> GetAll();
        War GetById(int id);

        bool Delete(War war);

        War Update(War war);
    }
}
