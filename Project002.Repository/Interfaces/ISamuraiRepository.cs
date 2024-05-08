﻿using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface ISamuraiRepository
    {
        Samurai Create(Samurai samurai);
        List<Samurai> GetAll();
        Samurai GetById(int id);
        bool Delete(Samurai samurai);

        void CreateSamuraiWithLists(Samurai samurai);
        Samurai Update(Samurai samurai);

    }

}
