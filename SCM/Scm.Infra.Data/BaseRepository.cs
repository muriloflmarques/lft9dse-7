using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Scm.Domain;
using Smc.Infra.Data.Interface;

namespace Smc.Infra.Data
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ScmDbContext _scmDbContext;

        public BaseRepository(ScmDbContext scmDbContext)
        {
            this._scmDbContext = scmDbContext;
        }

        public void Delete(T obj)
        {
            obj.SetDeleteDate();
            this.Update(obj);
        }

        public void Delete(IEnumerable<T> objs)
        {
            foreach (var obj in objs)
                this.Delete(obj);
        }

        public void Insert(T obj)
        {
            _scmDbContext.Add(obj);
        }

        public void Insert(IEnumerable<T> objs)
        {
            foreach (var obj in objs)
                this.Insert(obj);
        }

        public T SelectById(IQueryable<T> dbSet, int id) =>
            dbSet.FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> SelectByQuery(IQueryable<T> dbSet,
            Expression<Func<T, bool>> query) =>
            dbSet.Where(query).ToList();

        public T SelectFirstByQuery(IQueryable<T> dbSet,
             Expression<Func<T, bool>> query) =>
            this.SelectByQuery(dbSet, query).FirstOrDefault();

        public void Update(T obj)
        {
            obj.SetChangeDate();
            this._scmDbContext.Update(obj);
        }

        public void Update(IEnumerable<T> objs)
        {
            foreach (var obj in objs)
                this.Update(obj);
        }

        public void Dispose()
        {
            this._scmDbContext?.Dispose();
        }

        private void CheckIfNull(T obj)
        {
            if (obj == null) { }
        }

        public abstract IQueryable<T> GetDbSet();

        public abstract IQueryable<T> GetDbSetAsNoTracking();

        public abstract IQueryable<T> AddDefaultIncludeIntoDbSet(IQueryable<T> dbSet);
    }
}