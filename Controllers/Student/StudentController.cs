using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstudentApplication.Models;
using AstudentApplication.Models.DataModel;
using AstudentApplication.Repository.Interface.ITblRepository;
using AstudentApplication.Repository.Interface.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstudentApplication.Controllers.Student
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public StudentController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult RegisterPrimaryInfo(StudentInfo student)
        {
            try
            {
                IActionResult response = Unauthorized();
                var newobject = new StudentPrimaryInfo()
                {
                    Sname=student.Sname,
                    Fname = student.Fname,
                    Lname = student.Lname,
                    Nationality = student.Nationality,
                    Address= student.Address,
                    BirthPlace = student.BirthPlace,
                    Class = student.Class,
                    Mentor=student.Mentor,
                    DOB=Convert.ToDateTime(student.DOB)
                };
                _repoWrapper.studprimary.Create(newobject);
                _repoWrapper.Save();
                response = Ok(new
                {
                    studentid = newobject.Studid
                });
                return response;
          
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("createInfo")]
        public IActionResult RegisterSecondaryInfo(StudentPrimaryInfos student)
        {
            try
            {
                var newobject = new StudentSecondaryInfo()
                {
                    BloodGroup = student.BloodGroup,
                    FatherName = student.FatherName,
                    Fthrcontact = student.Fthrcontact,
                    Height = student.Height,
                    Mtrcontact = student.Mtrcontact,
                    Mtrname = student.Mtrname,
                    Weight = student.Weight,
                    Studid = student.StudId,
                };
                _repoWrapper.studInfo.Create(newobject);
                _repoWrapper.Save();
                return Ok(newobject.Infoid);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
