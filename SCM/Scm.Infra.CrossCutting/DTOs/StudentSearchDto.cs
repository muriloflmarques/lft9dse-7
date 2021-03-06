﻿using System;

namespace Scm.Infra.CrossCutting.DTOs
{
    public struct StudentSearchDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string CountryName { get; set; }

        public string CourseName { get; set; }
        public DateTime? CourseDate { get; set; }
        public string CourseTeacherName { get; set; }
    }
}