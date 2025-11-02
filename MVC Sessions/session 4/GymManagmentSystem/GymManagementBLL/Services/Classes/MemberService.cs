using AutoMapper;
using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        //private readonly IGenericRepository<Member> _memberRepository;
        //private readonly IGenericRepository<MemberShip> _memberShipRepository;
        //private readonly IPlanRepository _planRepository;
        //private readonly IGenericRepository<HealthRecord> _healthRecordRepository;
        //private readonly IGenericRepository<MemberSession> _memberSessionRepository;

        //public MemberService(IGenericRepository<Member> memberRepository , 
        //    IGenericRepository<MemberShip> memberShipRepository,
        //    IPlanRepository planRepository,
        //    IGenericRepository<HealthRecord> healthRecordRepository,
        //    IGenericRepository<MemberSession> memberSessionRepository)
        //{
        //    _memberRepository = memberRepository;
        //    _memberShipRepository = memberShipRepository;
        //    _planRepository = planRepository;
        //    _healthRecordRepository = healthRecordRepository;
        //    _memberSessionRepository = memberSessionRepository;
        //}

        private readonly IUniteOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUniteOfWork uniteOfWork, IMapper mapper) 
        {
            _unitOfWork = uniteOfWork;
            _mapper = mapper;
        }

       
        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var Members = _unitOfWork.GetRepository<Member>().GetAll();
            if (Members == null || !Members.Any()) {
                return Enumerable.Empty<MemberViewModel>();
            }
            // manual mapping
            #region way one
            //var MemberViewModels = new List<MemberViewModel>();
            //foreach(var Member in Members)
            //{
            //    var MemberViewModel = new MemberViewModel()
            //    {
            //        Id = Member.Id,
            //        Name = Member.Name,
            //        Email = Member.Email,
            //        Photo = Member.Photo,
            //        Gender = Member.Gender.ToString(),
            //        Phone = Member.Phone,
            //    };
            //    MemberViewModels.Add(MemberViewModel);
            //}
            #endregion
            #region way two
            //var MemberViewModels = Members.Select(x => new MemberViewModel()
            //{
            //    Name = x.Name,
            //    Email = x.Email,
            //    Id = x.Id,
            //    Photo = x.Photo,
            //    Phone = x.Phone,
            //    Gender = x.Gender.ToString(),
            //});
            var MemberViewModels = _mapper.Map<IEnumerable<MemberViewModel>>(Members); 
            #endregion
            return MemberViewModels;
        }
        public bool CreateMember(CreateMemberViewModel createMember) 
        {
            try
            {

                //check if email already exist
                var EmailExists = isEmailExists(createMember.Email);
                //check if phone already exist
                var PhoneExists = isPhoneExists(createMember.Phone);
                if (EmailExists || PhoneExists) return false;

                //var Member = new Member()
                //{
                //    Name = createMember.Name,
                //    Email = createMember.Email,
                //    Phone = createMember.Phone,
                //    DateOfBirth = createMember.DateOfBirth,
                //    Address = new Address()
                //    {
                //        BuildingNumber = createMember.BuildingNumber,
                //        city = createMember.City,
                //        street = createMember.Street,
                //    },
                //    HealthRecord = new HealthRecord()
                //    {
                //        Height = createMember.HealthRecordViewModel.Height,
                //        Weight = createMember.HealthRecordViewModel.Weight,
                //        BloodType = createMember.HealthRecordViewModel.BloodType,
                //        Note = createMember.HealthRecordViewModel.Note,
                //    },
                //    Gender = createMember.Gender,
                //};
                var MappedMember = _mapper.Map<CreateMemberViewModel,Member>(createMember);
                _unitOfWork.GetRepository<Member>().Add(MappedMember);
                return _unitOfWork.SaveChanges()>0;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public MemberViewModel? GetMemberDetails(int memberId)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
            if (member == null) return null;
            
            //MemberViewModel? memberViewModel = new MemberViewModel()
            //{
            //    Name = member.Name,
            //    Email = member.Email,
            //    Phone = member.Phone,
            //    Photo = member.Photo,
            //    Gender = member.Gender.ToString(),
            //    DateOfBirth = member.DateOfBirth.ToString(),
            //    Address = $"{member.Address.BuildingNumber}-{member.Address.street}-{member.Address.city}",
            //};
            var memberViewModel = _mapper.Map<MemberViewModel>(member);
            
            var memberShip = _unitOfWork.GetRepository<MemberShip>().GetAll(X=>X.MemberId == memberId && X.Status=="Active").FirstOrDefault();
            if (memberShip is not null)
            {
                memberViewModel.MemberShipStartDate = memberShip.CreatedAt.ToShortDateString();
                memberViewModel.MemberShipEndDate = memberShip.EndDate.ToShortDateString();
                var plan = _unitOfWork.GetRepository<Plan>().GetById(memberShip.PlanId);
                memberViewModel.PlanName= plan?.Name;
            }
            return memberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecordDetails(int memberId)
        {
            var MemberHealthRecord = _unitOfWork.GetRepository<HealthRecord>().GetById(memberId);
            if(MemberHealthRecord == null) return null;

            //return new HealthRecordViewModel()
            //{
            //    Height = MemberHealthRecord.Height,
            //    Weight = MemberHealthRecord.Weight,
            //    BloodType = MemberHealthRecord.BloodType,
            //    Note = MemberHealthRecord.Note,
            //};

            return _mapper.Map<HealthRecordViewModel>(MemberHealthRecord);
        }

        public MemberToUpdateViewModel? GetMemberToUpdate(int memberId)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
            if (member == null) return null;
            //return new MemberToUpdateViewModel()
            //{
            //    Name = member.Name,
            //    Phone = member.Phone,
            //    Photo = member.Photo,
            //    Email = member.Email,
            //    BuildingNumber = member.Address.BuildingNumber,
            //    Street = member.Address.street,
            //    City = member.Address.city,
            //};
            return _mapper.Map<MemberToUpdateViewModel>(member);
        }

        public bool UpdateMemberDatails(int memberId, MemberToUpdateViewModel memberToUpdate)
        {
            try
            {
                //check if email already exist
                var EmailExists = isEmailExists(memberToUpdate.Email);
                //check if phone already exist
                var PhoneExists = isPhoneExists(memberToUpdate.Phone);
                if (EmailExists || PhoneExists) return false;

                var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
                if (member == null) return false;

                //member.Email = memberToUpdate.Email;
                //member.Phone = memberToUpdate.Phone;
                //member.Address.BuildingNumber = memberToUpdate.BuildingNumber;
                //member.Address.street = memberToUpdate.Street;
                //member.Address.city = memberToUpdate.City;

                //member.UpdatedAt = DateTime.Now;
                _mapper.Map(memberToUpdate, member);
                _unitOfWork.GetRepository<Member>().Update(member);

                return _unitOfWork.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveMember(int memberId)
        {
            try
            {
                var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
                if (member == null) return false;

                var hasAcitveMemberSessions = _unitOfWork.GetRepository<MemberSession>().GetAll(X=>X.MemberId == memberId && X.Session.StartDate > DateTime.Now).Any();
                if(hasAcitveMemberSessions) return false;

                var MemberShips = _unitOfWork.GetRepository<MemberShip>().GetAll(X => X.MemberId == memberId);
                if (MemberShips.Any())
                {
                    foreach (var ship in MemberShips)
                    {
                        _unitOfWork.GetRepository<MemberShip>().Delete(ship);
                    }
                }
                _unitOfWork.GetRepository<Member>().Delete(member);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        #region healper methods
        private bool isEmailExists(string Email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(X => X.Email == Email).Any();
        }
        private bool isPhoneExists(string Phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(X => X.Phone == Phone).Any();
        }

       
        #endregion
    }
}
