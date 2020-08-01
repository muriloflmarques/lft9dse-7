using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SCM_API.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Course Name")]
        public string Name { get; set; }

        [DisplayName("Course Capacity")]
        public int Capacity { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DisplayName("Course Code")]
        public string Code { get; set; }
    }
}