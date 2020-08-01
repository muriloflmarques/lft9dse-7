using Scm.Infra.CrossCutting.Enum;
using SCM_API.Models.Adreess;
using SCM_API.Models.Course;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public AddressViewModel[] Addresses { get; set; }
        public CourseViewModel[] Courses { get; set; }
    }
}