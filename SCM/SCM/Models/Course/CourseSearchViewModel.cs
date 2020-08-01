﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SCM_API.Models.Course
{
    public class CourseSearchViewModel
    {
        [DisplayName("Course Name")]
        public string CourseName { get; set; }

        [DisplayName("Course Date")]
        [DataType(DataType.Date)]
        public DateTime? CourseDate { get; set; }

        [DisplayName("Teacher Name")]
        public string CourseTeacherName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}