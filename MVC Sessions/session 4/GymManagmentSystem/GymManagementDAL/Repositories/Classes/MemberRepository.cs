using GymManagementDAL.Data.Contexts;
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
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly GymDbContext _dbContext;
        public MemberRepository(GymDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        int IMemberRepository.Delete(int id)
        {
            Member member = GetById(id);
            if (member == null)
            {
                return 0;
            }
            else
            {
                _dbContext.Members.Remove(member);
                return _dbContext.SaveChanges();
            }
        }
    }
}
