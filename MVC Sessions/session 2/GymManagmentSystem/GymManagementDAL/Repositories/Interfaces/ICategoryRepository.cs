using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    internal interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        // get by id
        Category? GetById(int id);

        //add
        int Add(Category category);

        //update
        int Update(Category category);

        //delete
        int Delete(Category category);
    }
}
