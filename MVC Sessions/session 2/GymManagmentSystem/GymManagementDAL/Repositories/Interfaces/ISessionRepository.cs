using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    internal interface ISessionRepository
    {
        IEnumerable<Session> GetAll();
        // get by id
        Session? GetById(int id);

        //add
        int Add(Session session);

        //update
        int Update(Session session);

        //delete
        int Delete(Session session);
    }
}
