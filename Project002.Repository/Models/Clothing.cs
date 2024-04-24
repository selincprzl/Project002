using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Clothing
    {
        public int ClothingId { get; set; }
        public string ClothingName { get; set; }
        public string ClothingDescription { get; set; }
        public List<Samurai>? Samurai { get; set; }

    }
}
