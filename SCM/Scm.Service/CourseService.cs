using Scm.Domain;
using Scm.Infra.CrossCutting.CustomException;
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

        public Course GetById(int id) =>
            _courseRepository.GetById(id);

        public Course GetByIdOrThrowException(int id) =>
            this.GetById(id)
            ??
            throw new BusinessLogicException($"Course not found - Id: {id}");

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

        public IEnumerable<Course> SelectStudentsAvailableCourses(int idStudent)
        {
            var dbSet = _courseRepository.AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

            //Do NOT select those courses whose has the informed idStudent
            return _courseRepository.SelectByQuery(dbSet,
                co => !co.StudentCourses.Any(stCo => stCo.Student.Id == idStudent));
        }

        public IEnumerable<Course> SelectStudentsEnrolledCoursesTo(int idStudent)
        {
            var dbSet = _courseRepository.AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

            //Only select those courses whose has the informed idStudent
            return _courseRepository.SelectByQuery(dbSet,
                co => co.StudentCourses.Any(stCo => stCo.Student.Id == idStudent));
        }
    }
}