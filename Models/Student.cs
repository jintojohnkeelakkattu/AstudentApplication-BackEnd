using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Models
{
    [Table("StudentPrimaryInfo")]

    public class StudentPrimaryInfo
    {
        [Key]
        public int Studid { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Lname { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public string Mentor { get; set; }
        public string Address { get; set; }
        public string Class { get; set; }
    }

    [Table("StudentsecondaryInfo")]

    public class StudentSecondaryInfo
    {
        [Key]
        public int Infoid { get; set; }
        public int Studid { get; set; }
        public string FatherName { get; set; }
        public string Fthrcontact { get; set; }
        public string Mtrname { get; set; }
        public string Mtrcontact { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodGroup { get; set; }
    }
}
