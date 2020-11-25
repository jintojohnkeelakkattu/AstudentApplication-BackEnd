using AstudentApplication.Models;
using AstudentApplication.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Interface.ITblRepository
{
    public interface LoginInfoIRepository : IRepositoryBase<tbl_login>
    {
        public List<LoginInfo> Get(string UserName);
    }
}
