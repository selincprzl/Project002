using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface ITimePeriodRepository
    {
        TimePeriod Create(TimePeriod timePeriod);
        List<TimePeriod> GetAll();
        TimePeriod GetById(int id);

        bool Delete(TimePeriod timePeriod);

        TimePeriod Update(TimePeriod timePeriod);
    }
}
