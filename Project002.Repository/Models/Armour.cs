using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Armour
    {
        public int? ArmourId { get; set; }
        public string? ArmourName { get; set; }

        public string? ArmourDescription { get; set; }
        public List<Samurai>? Samurai { get; set; }

    }
}
