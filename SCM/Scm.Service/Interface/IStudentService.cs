using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using System.Collections.Generic;

namespace Scm.Service.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> SelectStudents(SearchStudentDto selectStudentDto);
    }
}