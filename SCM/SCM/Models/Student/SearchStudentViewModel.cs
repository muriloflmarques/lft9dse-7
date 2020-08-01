using System;

namespace SCM_API.Models.Student
{
    public class SearchStudentViewModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string CountryName { get; set; }

        public string CourseName { get; set; }
        public DateTime? CourseDate { get; set; }
        public string CourseTeacherName { get; set; }
    }
}