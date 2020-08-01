using Scm.Infra.Data.Interface;
using Scm.Service.Interface;

namespace Scm.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
    }
}