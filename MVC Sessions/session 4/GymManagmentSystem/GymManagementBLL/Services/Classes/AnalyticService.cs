using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.AnalyticsViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class AnalyticService : IAnalyticsService
    {
        private readonly IUniteOfWork _uniteOfWork;
        public AnalyticService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public AnalyticsViewModel GetAnalyticsData()
        {
            return new AnalyticsViewModel()
            {
                ActiveMembers = _uniteOfWork.GetRepository<MemberShip>().GetAll(x => x.Status == "Active").Count(),
                TotalMembers = _uniteOfWork.GetRepository<Member>().GetAll().Count(),
                TotalTrainers = _uniteOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpcomingSessions = _uniteOfWork.SessionRepository.GetAll(x => x.StartDate > DateTime.Now).Count(),
                OngoingSessions = _uniteOfWork.SessionRepository.GetAll(x => x.StartDate <= DateTime.Now && x.EndDate > DateTime.Now).Count(),
                CompletedSessions = _uniteOfWork.SessionRepository.GetAll(x => x.EndDate <= DateTime.Now).Count(),
            };
        }
    }
}
