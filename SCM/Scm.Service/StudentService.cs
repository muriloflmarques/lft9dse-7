using Microsoft.EntityFrameworkCore.Internal;
using Scm.Domain;
using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
using Scm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Scm.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseService _courseService;

        public StudentService(IStudentRepository studentRepository, ICourseService courseService)
        {
            this._studentRepository = studentRepository;
            this._courseService = courseService;
        }

        public Student GetById(int id) =>
            _studentRepository.GetById(id);

        public Student GetByIdOrThrowException(int id) =>
            this.GetById(id) 
            ??
            throw new BusinessLogicException($"Student not found - Id: {id}");        

        public void IncludeCourseInStudent(int idStudent, int idCourse)
        {
            var student = this.GetByIdOrThrowException(idStudent);
            var course = _courseService.GetByIdOrThrowException(idCourse);

            student.AddCourse(course);

            _studentRepository.Update(student);
        }

        public void RemoveCourseFromStudent(int idStudent, int idCourse)
        {
            var student = this.GetByIdOrThrowException(idStudent);
            var course = _courseService.GetByIdOrThrowException(idCourse);

            student.RemoveCourse(course);

            _studentRepository.Update(student);
        }

        public IEnumerable<Student> SelectStudents(StudentSearchDto searchStudentDto)
        {
            var dbSet = _studentRepository.AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSetAsNoTracking());

            return _studentRepository.SelectByQuery(dbSet,
                st => 
                    (string.IsNullOrWhiteSpace(searchStudentDto.FirstName) || st.FirstName.Contains(searchStudentDto.FirstName))
                    &&
                    (string.IsNullOrWhiteSpace(searchStudentDto.Surname) || st.Surname.Contains(searchStudentDto.Surname))                    
                    &&
                    (string.IsNullOrWhiteSpace(searchStudentDto.CourseName) || st.StudentCourses.Any(stCo => stCo.Course.Name.Contains(searchStudentDto.CourseName)))
                    &&
                    (!searchStudentDto.CourseDate.HasValue || st.StudentCourses.Any(stCo => stCo.Course.CreationDate <= searchStudentDto.CourseDate.Value && stCo.Course.EndDate >= searchStudentDto.CourseDate.Value))
                    &&
                    (string.IsNullOrWhiteSpace(searchStudentDto.CourseTeacherName) || st.StudentCourses.Any(stCo => stCo.Course.TeacherName.Contains(searchStudentDto.CourseTeacherName))));
        }
    }
}