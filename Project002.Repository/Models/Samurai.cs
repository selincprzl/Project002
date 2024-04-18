using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{   /// <summary>
/// 1) Create Models
/// 2) Install Packages 
/// 3) Create DatabaseContext class
/// 4) Program.cs add our Database service and connection string
/// 5) Go to console => add-migration name
/// 6) Go to console => database-update
/// 7) Dependency injection activation
/// 8) Done
/// 
/// /// /// </summary>
    public class Samurai
    {
        //Entity Framework works with PK...... Id or ClassName+Id
        public int SamuraiId { get; set; }
        public string SamuraiName { get; set; }

        public string Description { get; set; }

        public int Age { get; set; }

        public int ClanId { get; set; }

        public int TransportId { get; set; }

        public int WarId { get; set; }
        public int ArmourId { get; set; }
        public int ClothingId { get; set; }


    }
}
