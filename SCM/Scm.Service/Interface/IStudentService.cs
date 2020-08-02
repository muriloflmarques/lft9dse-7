using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using System.Collections.Generic;

namespace Scm.Service.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> SelectStudents(StudentSearchDto selectStudentDto);

        void IncludeCourseInStudent(int idStudent, int idCourse);
        void RemoveCourseFromStudent(int idStudent, int idCourse);
        Student GetById(int id);
        Student GetByIdOrThrowException(int id);
    }
}