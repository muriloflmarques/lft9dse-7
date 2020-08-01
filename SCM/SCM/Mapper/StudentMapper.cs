using Scm.Domain;
using Scm.Infra.CrossCutting.Enum;
using Scm.Infra.CrossCutting.Helpers;
using SCM_API.Models.Student;
using System.Linq;

namespace SCM_API.Mapper
{
    public static class StudentMapper
    {
        public static StudentViewModel MapToViewModel(this Student student)
        {
            return new StudentViewModel()
            {
                Id = student.Id,

                FirstName = student.FirstName,
                Surname = student.Surname,
                DateOfBirth = student.DateOfBirth.ToString("dd/MM/yyyy"),
                Gender = EnumHelper.GetDescription<GenderEnum>(student.Gender),

                Addresses = student?.Addresses
                    .Select(ad => { return ad.MapToViewModel(); })?.ToArray(),

                Courses = student.StudentCourses.Select(stCo => stCo.Course)
                .Select(co => { return co.MapToViewModel(); }).ToArray()
            };
        }
    }
}