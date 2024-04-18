﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class War
    {   
        public int WarId { get; set; }
        public string WarName { get; set;}
        public int DeathCount { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
        public string Location { get; set; }

    }
}