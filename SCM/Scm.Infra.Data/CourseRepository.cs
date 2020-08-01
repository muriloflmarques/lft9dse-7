using Microsoft.EntityFrameworkCore;
using Scm.Domain;
using Scm.Infra.Data.Interface;
using Smc.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scm.Infra.Data
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ScmDbContext scmDbContext) : base(scmDbContext)
        {

        }

        public override IQueryable<Course> AddDefaultIncludeIntoDbSet(IQueryable<Course> dbSet) =>
            dbSet
                .Include(co => co.StudentCourses).ThenInclude(stCo => stCo.Student);

        public override IQueryable<Course> GetDbSet() =>
            this._scmDbContext.Set<Course>();

        public override IQueryable<Course> GetDbSetAsNoTracking()=>
            this.GetDbSet().AsNoTracking();
    }
}
