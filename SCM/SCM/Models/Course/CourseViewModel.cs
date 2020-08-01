using System.ComponentModel;

namespace SCM_API.Models.Course
{
    public class CourseViewModel
    {
        [DisplayName("Course Id")]
        public int Id { get; set; }

        [DisplayName("Course Name")]
        public string Name { get; set; }

        [DisplayName("Course Capacity")]
        public int Capacity { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        [DisplayName("Start Date")]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        public string EndDate { get; set; }

        [DisplayName("Course Code")]
        public string Code { get; set; }
    }
}