using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rubel_Rana_1249804.ViewModels
{
    public class StudentCourseRpt
    {
        [Key]
        public string Course
        {
            get;set;
        }
        public IEnumerable<Student> Students { get; set; }
    }
}