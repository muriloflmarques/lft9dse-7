using Scm.Domain;
using Smc.Infra.Data.Interface;

namespace Scm.Infra.Data.Interface
{
    public  interface ICourseRepository : IBaseRepository<Course>
    {
        Course GetById(int id);
    }
}
