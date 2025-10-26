using AutoMapper;
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
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.TrainerName, Options => Options.MapFrom(Src => Src.SessionTrainer.Name))
                .ForMember(dest => dest.CategoryName, Options => Options.MapFrom(Src => Src.SessionCategory.CategoryName))
                .ForMember(dest => dest.AvailableSlots, Options=>Options.Ignore());
            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<Session,UpdateSessionViewModel>().ReverseMap();
        }
    }
}
