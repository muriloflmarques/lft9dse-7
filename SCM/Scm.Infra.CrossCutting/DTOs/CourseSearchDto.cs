using System;

namespace Scm.Infra.CrossCutting.DTOs
{
    public struct CourseSearchDto
    {
        public string CourseName { get; set; }
        public DateTime? CourseDate { get; set; }
        public string CourseTeacherName { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}