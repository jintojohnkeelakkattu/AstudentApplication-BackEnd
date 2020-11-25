using AstudentApplication.Models;
using AstudentApplication.Repository.Interface.ITblRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Wrapper.TblRepository
{
    public class StudentOtherInfoRepository : RepositoryBase<StudentSecondaryInfo>, StudentSecondaryInfoIRepository
    {
        public StudentOtherInfoRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
