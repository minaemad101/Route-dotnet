using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Classes
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly GymDbContext _dbContext;
        public ISessionRepository SessionRepository { get; }
        public UniteOfWork(GymDbContext dbContext, ISessionRepository sessionRepository) {
            _dbContext = dbContext;
            SessionRepository = sessionRepository;
        }
        private readonly Dictionary<Type, object> _repositoryDictionary = new();

        

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var EntityType = typeof(TEntity);
            if (_repositoryDictionary.ContainsKey(EntityType)) 
            { 
                return (IGenericRepository<TEntity>)_repositoryDictionary[EntityType];
            }
            var NewRepo = new GenericRepository<TEntity>(_dbContext);
            _repositoryDictionary[EntityType] = NewRepo;
            return NewRepo;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
