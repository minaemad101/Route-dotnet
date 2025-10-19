using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    internal interface IPlanRepository
    {
        IEnumerable<Plan> GetAll();
        // get by id
        Plan? GetById(int id);

        //add
        int Add(Plan plan);

        //update
        int Update(Plan plan);

        //delete
        int Delete(Plan plan);
    }
}
