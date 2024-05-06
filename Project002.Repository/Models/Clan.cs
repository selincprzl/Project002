using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Clan
    {
        public int? ClanId { get; set; }

        public string? ClanName { get; set; }
        public List<War>? Wars { get; set; }

        [JsonIgnore]
        public List<Samurai>? Samurai { get; set; }


    }
}
