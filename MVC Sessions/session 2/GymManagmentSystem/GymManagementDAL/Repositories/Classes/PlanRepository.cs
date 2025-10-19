﻿using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Classes
{
    internal class PlanRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Plan plan)
        {
            _dbContext.Plans.Add(plan);
            return _dbContext.SaveChanges();
        }

        public int Delete(Plan plan)
        {
            _dbContext.Plans.Remove(plan);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Plan> GetAll() => _dbContext.Plans.ToList();

        public Plan? GetById(int id) => _dbContext.Plans.Find(id);

        public int Update(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();
        }
    }
}
