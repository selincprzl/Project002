using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Weapon
    {
        public int? WeaponId { get; set; }
        public string? WeaponName { get; set; }
        [JsonIgnore]

        public List<Samurai>? Samurai { get; set; }

    }
}
