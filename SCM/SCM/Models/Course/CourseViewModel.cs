using System.ComponentModel;

namespace SCM_API.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Course Name")]
        public string Name { get; set; }
        public int Capacity { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        [DisplayName("Start Date")]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        public string EndDate { get; set; }
        public string Code { get; set; }
    }
}