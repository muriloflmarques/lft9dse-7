﻿using Microsoft.EntityFrameworkCore;
using Scm.Domain;
using Scm.Infra.Data.Interface;
using Smc.Infra.Data;
using System.Linq;

namespace Scm.Infra.Data
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ScmDbContext scmDbContext) : base(scmDbContext) { }

        public override IQueryable<Student> AddDefaultIncludeIntoDbSet(IQueryable<Student> dbSet) =>
            dbSet
                .Include(st => st.StudentCourses).ThenInclude(stCo => stCo.Course);

        public Student GetById(int id)
        {
            var dbSet = this.AddDefaultIncludeIntoDbSet(this.GetDbSetAsNoTracking());

            return base.SelectById(dbSet, id);
        }

        public override IQueryable<Student> GetDbSet() =>
            this._scmDbContext.Set<Student>();

        public override IQueryable<Student> GetDbSetAsNoTracking() =>
            this.GetDbSet().AsNoTracking();

        public void RemoveStudentCourse(StudentCourse studentCourse) =>
            _scmDbContext.Remove(studentCourse);
    }
}