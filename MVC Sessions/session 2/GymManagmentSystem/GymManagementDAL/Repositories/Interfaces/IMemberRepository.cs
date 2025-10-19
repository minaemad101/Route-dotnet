﻿using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    internal interface IMemberRepository
    {
        //get all
        IEnumerable<Member> GetAll();
        // get by id
        Member? GetById(int id);
        
        //add
        int Add(Member member);

        //update
        int Update(Member member);

        //delete
        int Delete(int Id);
    }
}
