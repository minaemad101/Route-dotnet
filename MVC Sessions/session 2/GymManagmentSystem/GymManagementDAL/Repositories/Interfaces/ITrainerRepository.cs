using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    internal interface ITrainerRepository
    {
        IEnumerable<Trainer> GetAll();
        // get by id
        Trainer? GetById(int id);

        //add
        int Add(Trainer trainer);

        //update
        int Update(Trainer trainer);

        //delete
        int Delete(Trainer trainer);
    }
}
