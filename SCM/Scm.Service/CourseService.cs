using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
using Scm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Scm.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        public IEnumerable<Course> SelectCourses(CourseSearchDto courseSearchDto)
        {
            var dbSet = _courseRepository.AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

            return _courseRepository.SelectByQuery(dbSet,
                co =>
                    (string.IsNullOrWhiteSpace(courseSearchDto.CourseName) || co.Name.Contains(courseSearchDto.CourseName))
                    &&
                    (string.IsNullOrWhiteSpace(courseSearchDto.CourseTeacherName) || co.TeacherName.Contains(courseSearchDto.CourseTeacherName))
                    &&
                    (!courseSearchDto.CourseDate.HasValue || co.CreationDate <= courseSearchDto.CourseDate.Value && co.EndDate >= courseSearchDto.CourseDate.Value)
                    &&
                    (string.IsNullOrWhiteSpace(courseSearchDto.FirstName) || co.StudentCourses.Any(stCo => stCo.Student.FirstName.Contains(courseSearchDto.CourseName)))
                    &&
                    (string.IsNullOrWhiteSpace(courseSearchDto.Surname) || co.StudentCourses.Any(stCo => stCo.Student.Surname.Contains(courseSearchDto.Surname))));
        }
    }
}