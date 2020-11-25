using AstudentApplication.Models;
using AstudentApplication.Repository.Interface.ITblRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Interface.Wrapper.TblRepository
{
    public class StudentPrimaryRepository : RepositoryBase<StudentPrimaryInfo>, StudentPrimaryInfoIRepository
    {
        public StudentPrimaryRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
