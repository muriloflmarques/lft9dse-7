using Scm.Infra.CrossCutting.Enum;
using SCM_API.Models.Course;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SCM_API.Models.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }

        [DisplayName("First Address")]
        public string FirstAddress { get; set; }

        [DisplayName("Second Address")]
        public string SecondAddress { get; set; }

        [DisplayName("Third Address")]
        public string ThirdAddress { get; set; }

        public CourseViewModel[] Courses { get; set; } = new CourseViewModel[] { };

        public int Enrolled { get { return this.Courses.Count(); }  }
    }
}