using Scm.Domain;
using Scm.Infra.CrossCutting.Helper;
using SCM_API.Models.Course;

namespace SCM_API.Mapper
{
    public static class CourseMapper
    {
        public static CourseViewModel MapToViewModel(this Course course)
        {
            return new CourseViewModel()
            {
                Id = course.Id,

                Name = course.Name,
                TeacherName = course.TeacherName,
                StartDate = course.StartDate.FormatDateTimeToViewModel(),
                EndDate = course.EndDate.FormatDateTimeToViewModel(),
                Capacity = course.Capacity
            };
        }
    }
}