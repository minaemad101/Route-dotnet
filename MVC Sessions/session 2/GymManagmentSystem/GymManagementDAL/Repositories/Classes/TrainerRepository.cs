using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Classes
{
    internal class TrainerRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public TrainerRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Trainer trainer)
        {
            _dbContext.Trainers.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int Delete(Trainer trainer)
        {
            _dbContext.Trainers.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll() => _dbContext.Trainers.ToList();

        public Trainer? GetById(int id) => _dbContext.Trainers.Find(id);

        public int Update(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();
        }
    }
}
