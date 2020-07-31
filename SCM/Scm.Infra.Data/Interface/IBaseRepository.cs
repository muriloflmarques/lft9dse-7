﻿using Scm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smc.Infra.Data.Interface
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        void Insert(T obj);
        void Insert(IEnumerable<T> objs);
        void Update(T obj);
        void Update(IEnumerable<T> objs);
        void Delete(T obj);
        void Delete(IEnumerable<T> objs);

        T SelectById(IQueryable<T> dbSet, int id);
        IEnumerable<T> SelectByQuery(IQueryable<T> dbSet, Expression<Func<T, bool>> query);
        T SelectFirstByQuery(IQueryable<T> dbSet, Expression<Func<T, bool>> query);

        IQueryable<T> GetDbSet();
        IQueryable<T> GetDbSetAsNoTracking();
        IQueryable<T> AddDefaultIncludeIntoDbSet(IQueryable<T> dbSet);
    }
}