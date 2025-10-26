using AutoMapper;
using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.SessionViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    internal class SessionService:ISessionService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public SessionService(IUniteOfWork uniteOfWork ,IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel createSession)
        {
            try
            {

                if (!IsTrainerExists(createSession.TrainerId)) return false;
                if (!IsCategoryExists(createSession.CategoryId)) return false;
                if (!isValidDateRange(createSession.StartDate, createSession.EndDate)) return false;
                var MappedSession = _mapper.Map<CreateSessionViewModel, Session>(createSession);
                _uniteOfWork.SessionRepository.Add(MappedSession);
                return _uniteOfWork.SaveChanges() > 0;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var Sessions = _uniteOfWork.SessionRepository.GetAllSessionsWithTrainersAndCategories();
            if (Sessions is null || !Sessions.Any()) return [];
            //return Sessions.Select(x => new SessionViewModel()
            //{
            //    Id = x.Id,
            //    Capacity = x.Capacity,
            //    Description = x.Description,
            //    EndDate = x.EndDate,
            //    StartDate = x.StartDate,
            //    TrainerName = x.SessionTrainer.Name,
            //    CategoryName = x.SessionCategory.CategoryName,
            //    AvailableSlots = x.Capacity - _uniteOfWork.SessionRepository.GetCountOfBookedSlots(x.Id)
            //});
            var MappedSessions = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(Sessions);
            return MappedSessions;
        }

        public SessionViewModel? GetSessionById(int sessionId)
        {
            var Session = _uniteOfWork.SessionRepository.GetSessionByIdWithTrainerAndCategory(sessionId);
            if (Session is null) return null;
            //return new SessionViewModel(){
            //    Capacity = Session.Capacity,
            //    Description = Session.Description,
            //    EndDate = Session.EndDate,
            //    StartDate = Session.StartDate,
            //    TrainerName = Session.SessionTrainer.Name,
            //    CategoryName = Session.SessionCategory.CategoryName,
            //    AvailableSlots = Session.Capacity - _uniteOfWork.SessionRepository.GetCountOfBookedSlots(Session.Id)
            //};
            var MappedSession = _mapper.Map<Session,SessionViewModel>(Session);
            return MappedSession;
        }
        public UpdateSessionViewModel? GetSessionToUpdate(int sessionId)
        {
            var Session = _uniteOfWork.SessionRepository.GetById(sessionId);
            if(!isSessionAvailableForUpdate(Session)) return null;
            return _mapper.Map<Session,UpdateSessionViewModel>(Session);


        }

        public bool UpdateSessionDatails(int sessionId, UpdateSessionViewModel sessionToUpdate)
        {
            try
            {

                var Session = _uniteOfWork.SessionRepository.GetById(sessionId);
                if (!isSessionAvailableForUpdate(Session)) return false;
                if (!IsTrainerExists(sessionToUpdate.TrainerId)) return false;
                if (!isValidDateRange(sessionToUpdate.StartDate, sessionToUpdate.EndDate)) return false;
                _mapper.Map(sessionToUpdate, Session);
                Session.UpdatedAt = DateTime.Now;
                return _uniteOfWork.SaveChanges() > 0;
            }
            catch (Exception ex) {
                return false;
            }


        }
        public bool RemoveSession(int sessionId)
        {
            try
            {

                var session = _uniteOfWork.SessionRepository.GetById(sessionId);
                if (!isSessionAvailableForRemove(session)) return false;
                _uniteOfWork.SessionRepository.Delete(session!);
                return _uniteOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #region Helpers
        private bool IsTrainerExists(int TrainerId)
        {
            return _uniteOfWork.GetRepository<Trainer>().GetById(TrainerId) is not null;
        }
        private bool IsCategoryExists(int CategoryId)
        {
            return _uniteOfWork.GetRepository<Category>().GetById(CategoryId) is not null;
        }
        private bool isValidDateRange(DateTime StartDate, DateTime EndDate)
        {
            return StartDate < EndDate && StartDate > DateTime.Now;     
        }

        private bool isSessionAvailableForUpdate(Session session)
        {
            if(session is null) return false;
            if (session.EndDate < DateTime.Now) return false;
            if (session.StartDate <= DateTime.Now) return false;
            
            var HasActiveBooking = _uniteOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;
            return !HasActiveBooking;
        }
        private bool isSessionAvailableForRemove(Session session)
        {
            if (session is null) return false;
            if (session.StartDate > DateTime.Now) return false;
            if (session.StartDate <= DateTime.Now && session.EndDate>DateTime.Now) return false;

            var HasActiveBooking = _uniteOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;
            return !HasActiveBooking;

        }

        #endregion
    }
}
