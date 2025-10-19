using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Member : GymUser
    {
        // join date is the created at column
        public string? Photo { get; set; }

        // relations
        // member and health record 1 to 1
        public HealthRecord HealthRecord { get; set; } = null!;

        // m to m relation for plan
        public ICollection<MemberShip> MemberShips { get; set; } = null!;

        // m to m relation for session
        public ICollection<MemberSession> MemberSessions { get; set; }

    }
}
