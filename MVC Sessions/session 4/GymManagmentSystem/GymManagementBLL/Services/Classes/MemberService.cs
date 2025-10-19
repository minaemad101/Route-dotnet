using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    internal class MemberService : IMemberService
    {
        private readonly GenericRepository<Member> _memberRepository;

        public MemberService(GenericRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

       
        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var Members = _memberRepository.GetAll();
            if (Members == null || !Members.Any()) {
                return Enumerable.Empty<MemberViewModel>();
            }
            var MemberViewModels = new List<MemberViewModel>();
            foreach(var Member in Members)
            {
                var MemberViewModel = new MemberViewModel()
                {
                    Id = Member.Id,
                    Name = Member.Name,
                    Email = Member.Email,
                    Photo = Member.Photo,
                    Gender = Member.Gender.ToString(),
                    Phone = Member.Phone,
                };
                MemberViewModels.Add(MemberViewModel);
            }
            return MemberViewModels;
        }
    }
}
