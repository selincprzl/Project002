using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Clan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ClanId { get; set; }

        public string? ClanName { get; set; }

        public string? Description { get; set; }
        public string? Img { get; set; }

        [JsonIgnore]
        public Samurai? Samurai { get; set; }


    }
}