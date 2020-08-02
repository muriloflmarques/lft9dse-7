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
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Capacity = course.Capacity,
                Code = course.Code
            };
        }

        public static Course MapToDomain(this CourseViewModel courseViewModel) =>
            new Course(
                name: courseViewModel.Name,
                teacherName: courseViewModel.TeacherName,
                startDate: courseViewModel.StartDate,
                endDate: courseViewModel.EndDate,
                capacity: courseViewModel.Capacity);       
    }
}