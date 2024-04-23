using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Horse
    {
        public int? HorseId { get; set; }
        public string? HorseName { get; set; }
        public string? Description { get; set; }

        public Samurai? Samurai { get; set; }

    }
}
