﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Rank
    {
        public int? RankId { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public List<Samurai>? Samurai { get; set; }

    }
}
