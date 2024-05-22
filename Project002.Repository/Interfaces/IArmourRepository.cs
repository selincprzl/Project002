﻿using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Interfaces
{
    public interface IArmourRepository 
    {
        List<Armour> GetAll(); // Method signature to retrieve all armour data
    }


}