using SCM.Models;

namespace SCM_API.Models.Course
{
    public class CourseCreateViewModel
    {
        public CourseViewModel Course { get; set; }
        public ErrorViewModel Error { get; set; }
    }
}