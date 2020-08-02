using Scm.Domain;
using Smc.Infra.Data.Interface;

namespace Scm.Infra.Data.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Student GetById(int id);
        void RemoveStudentCourse(StudentCourse studentCourse);
    }
}