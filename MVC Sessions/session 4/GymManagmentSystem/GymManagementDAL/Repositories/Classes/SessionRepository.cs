﻿using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Classes
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDbContext _dbContext;
        public SessionRepository(GymDbContext dbContext):base(dbContext) {
        _dbContext = dbContext;
        }
        public IEnumerable<Session> GetAllSessionsWithTrainersAndCategories()
        {
            return _dbContext.Sessions.Include(x => x.SessionTrainer).Include(x => x.SessionCategory).ToList();
        }

        public int GetCountOfBookedSlots(int sessionId)
        {
            return _dbContext.MembersSessions.Count(x=>x.SessionId == sessionId);
        }

        public Session? GetSessionByIdWithTrainerAndCategory(int Id)
        {
            return _dbContext.Sessions.Include(x => x.SessionTrainer).Include(x => x.SessionCategory).FirstOrDefault(x=>x.Id==Id);
        }
    }
}
