using Scm.Domain;
using SCM_API.Models.Course;

namespace SCM_API.Mapper
{
    public static class CourseMapper
    {
        public static CourseViewModel MapToViewModel(this Course course)
        {
            return new CourseViewModel();
        }
    }
}