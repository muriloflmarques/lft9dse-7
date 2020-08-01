using Microsoft.EntityFrameworkCore.Internal;
using Scm.Domain;
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

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
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
                    (string.IsNullOrWhiteSpace(searchStudentDto.CountryName) || st.Addresses.Any(ad=>ad.Country.Name.Contains(searchStudentDto.CountryName)))
                    &&
                    (string.IsNullOrWhiteSpace(searchStudentDto.CourseName) || st.StudentCourses.Any(stCo => stCo.Course.Name.Contains(searchStudentDto.CourseName)))
                    &&
                    (!searchStudentDto.CourseDate.HasValue || st.StudentCourses.Any(stCo => stCo.Course.CreationDate <= searchStudentDto.CourseDate.Value && stCo.Course.EndDate >= searchStudentDto.CourseDate.Value))
                    &&
                    (string.IsNullOrWhiteSpace(searchStudentDto.CourseTeacherName) || st.StudentCourses.Any(stCo => stCo.Course.TeacherName.Contains(searchStudentDto.CourseTeacherName))));
        }
    }
}