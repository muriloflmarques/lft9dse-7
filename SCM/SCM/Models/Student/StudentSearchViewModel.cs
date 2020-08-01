using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SCM_API.Models.Student
{
    public class StudentSearchViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        public string Surname { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
        
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        
        [DisplayName("Course Date")]
        [DataType(DataType.Date)]
        public DateTime? CourseDate { get; set; }

        [DisplayName("Teacher Name")] 
        public string CourseTeacherName { get; set; }
    }
}