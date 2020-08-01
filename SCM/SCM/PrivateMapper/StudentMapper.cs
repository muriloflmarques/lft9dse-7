using Scm.Domain;
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
                //DateOfBirth = student.DateOfBirth.FormatDateTimeToViewModel(),
                DateOfBirth = student.DateOfBirth,
                //Gender = EnumHelper.GetDescription<GenderEnum>(student.Gender),
                Gender = student.Gender,

                FirstAddress = student.FirstAddress,
                SecondAddress = student.SecondAddress,
                ThirdAddress = student.ThirdAddress,

                Courses = student.StudentCourses.Select(stCo => stCo.Course)
                    ?.Select(co => { return co.MapToViewModel(); })?.ToArray()
            };
        }

        public static Student MapToDomain(this StudentViewModel studentViewModel) =>
            new Student(
                firstName: studentViewModel.FirstName,
                surname: studentViewModel.Surname,
                dateOfBirth: studentViewModel.DateOfBirth,
                gender: studentViewModel.Gender,
                firstAddres: studentViewModel.FirstAddress,
                secondAddres: studentViewModel.SecondAddress,
                thirdAddres: studentViewModel.ThirdAddress);
    }
}