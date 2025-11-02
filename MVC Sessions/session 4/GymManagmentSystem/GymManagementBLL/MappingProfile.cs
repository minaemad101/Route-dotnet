using AutoMapper;
using GymManagementBLL.ViewModels.MemberViewModel;
using GymManagementBLL.ViewModels.SessionViewModel;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            MapSession();
            MapMember();
        }

        private void MapSession()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.TrainerName, Options => Options.MapFrom(Src => Src.SessionTrainer.Name))
                .ForMember(dest => dest.CategoryName, Options => Options.MapFrom(Src => Src.SessionCategory.CategoryName))
                .ForMember(dest => dest.AvailableSlots, Options=>Options.Ignore());
            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<Session,UpdateSessionViewModel>().ReverseMap();
        }

        private void MapMember()
        {
            //CreateMap<CreateMemberViewModel, Member>()
            //    .ForMember(dest => dest.Address, options => options.MapFrom(src => new Address() { BuildingNumber = src.BuildingNumber, city = src.City, street = src.Street }));
            CreateMap<CreateMemberViewModel, Member>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.HealthRecord,opt=>opt.MapFrom(src=>src.HealthRecordViewModel));

            CreateMap<CreateMemberViewModel, Address>()
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                .ForMember(dest => dest.street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.City));

            CreateMap<HealthRecordViewModel, HealthRecord>().ReverseMap();

            CreateMap<Member, MemberViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.DateOfBirth, opt=>opt.MapFrom(src => src.DateOfBirth.ToShortDateString()))
                .ForMember(dest => dest.Address,opt=>opt.MapFrom(src=>$"{src.Address.BuildingNumber} - {src.Address.street} - {src.Address.city}"));

            CreateMap<Member, MemberToUpdateViewModel>()
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.Address.BuildingNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.city));

            CreateMap<MemberToUpdateViewModel, Member>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Address.BuildingNumber = src.BuildingNumber;
                    dest.Address.street = src.Street;
                    dest.Address.city = src.City;
                    dest.UpdatedAt = DateTime.Now;
                });

        }
    }
}
