using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using System.Collections.Generic;

namespace Scm.Service.Interface
{
    public interface ICourseService
    {
        IEnumerable<Course> SelectCourses(CourseSearchDto courseSearchDto);
        IEnumerable<Course> SelectStudentsAvailableCourses(int idStudent);
        IEnumerable<Course> SelectStudentsEnrolledCoursesTo(int idStudent);

        Course GetById(int id);
        Course GetByIdOrThrowException(int id);
    }
}