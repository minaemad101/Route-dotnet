using GymManagementBLL.ViewModels.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();
        bool CreateMember(CreateMemberViewModel createMember);
        MemberViewModel? GetMemberDetails(int memberId);
        HealthRecordViewModel? GetMemberHealthRecordDetails(int memberId);
        MemberToUpdateViewModel? GetMemberToUpdate(int memberId);
        bool UpdateMemberDatails(int  memberId, MemberToUpdateViewModel memberToUpdate);
        bool RemoveMember(int memberId);
    }
}
