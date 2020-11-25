using AstudentApplication.Models;
using AstudentApplication.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<StudentPrimaryInfo> StudentPrimaryInfo { get; set; }
        public virtual DbSet<StudentSecondaryInfo> studInfo { get; set; }
        public virtual DbSet<tbl_login> tblUserInfo { get; set; }
    }

}