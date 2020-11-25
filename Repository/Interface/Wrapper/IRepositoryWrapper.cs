using AstudentApplication.Repository.Interface.ITblRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository.Interface.Wrapper
{
    public interface IRepositoryWrapper
    {
        StudentPrimaryInfoIRepository studprimary { get; }
        StudentSecondaryInfoIRepository studInfo { get;}
        LoginInfoIRepository loginInfo { get; }
        void Save();
    }
}
