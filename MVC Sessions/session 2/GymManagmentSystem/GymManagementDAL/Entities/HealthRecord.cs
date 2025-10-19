using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    // 1 to 1 relation with member shard primary key
    public class HealthRecord:BaseEntity
    {
        // id is a forign key for the member id
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string BloodType { get; set; } = null!;
        public string ? Note { get; set; }
    }
}
