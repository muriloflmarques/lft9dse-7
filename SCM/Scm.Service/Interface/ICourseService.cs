using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using System.Collections.Generic;

namespace Scm.Service.Interface
{
    public interface ICourseService
    {
        IEnumerable<Course> SelectCourses(CourseSearchDto courseSearchDto);
    }
}