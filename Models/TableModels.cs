using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Models
{
    [Table("tbl_login")]
    public class tbl_login
    {

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        [Key]
        public string UserId { get; set; }
    }
}
