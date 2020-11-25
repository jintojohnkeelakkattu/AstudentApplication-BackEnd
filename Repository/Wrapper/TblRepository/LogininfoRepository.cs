using AstudentApplication.Models;
using AstudentApplication.Models.DataModel;
using AstudentApplication.Repository.Interface.ITblRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Wrapper.TblRepository
{
    public class LogininfoRepository:RepositoryBase<tbl_login>, LoginInfoIRepository
    {
        private readonly IList<LoginInfo> _login;

        public LogininfoRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
        public List<LoginInfo> Get(string UserName) =>
    _login.AsEnumerable().Where(emp => emp.UserName == UserName).ToList();
    }
}

