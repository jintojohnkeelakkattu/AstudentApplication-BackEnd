using AstudentApplication.Repository.Interface.ITblRepository;
using AstudentApplication.Repository.Interface.Wrapper;
using AstudentApplication.Repository.Interface.Wrapper.TblRepository;
using AstudentApplication.Repository.Wrapper.TblRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private StudentPrimaryInfoIRepository _stud;
        private StudentSecondaryInfoIRepository _stud1;
        private LoginInfoIRepository _loginInfo;
        public StudentPrimaryInfoIRepository studprimary
        {
            get
            {
                if (_stud == null)
                {
                    _stud = new StudentPrimaryRepository(_repoContext);
                }
                return _stud;
            }
        }
        public StudentSecondaryInfoIRepository studInfo
        {
            get
            {
                if (_stud1 == null)
                {
                    _stud1 = new StudentOtherInfoRepository(_repoContext);
                }
                return _stud1;
            }
        }
        public LoginInfoIRepository loginInfo
        {
            get
            {
                if (_loginInfo == null)
                {
                    _loginInfo = new LogininfoRepository(_repoContext);
                }
                return _loginInfo;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
