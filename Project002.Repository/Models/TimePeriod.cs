using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class TimePeriod
    {
        public int TimePeriodId { get; set; }
        public string Date { get; set;}
        [JsonIgnore]

        public List<War>? War { get; set; }

    }
}
