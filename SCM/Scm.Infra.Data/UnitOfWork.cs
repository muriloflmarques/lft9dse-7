using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using Smc.Infra.Data.Interface;

namespace Smc.Infra.Data
{
    public class RawSQlCommand
    {
        public RawSQlCommand(string rawSqlString, object[] paramsForSql = null)
        {
            this.RawSqlString = rawSqlString;
            this.ParamsForSql = paramsForSql;
        }

        public string RawSqlString { get; protected set; }
        public object[] ParamsForSql { get; protected set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScmDbContext _scmDbContext;
        private IDbContextTransaction _transaction;

        public List<RawSQlCommand> RawSQlCommandList { get; private set; } = new List<RawSQlCommand>();

        public UnitOfWork(ScmDbContext scmDbContext)
        {
            this._scmDbContext = scmDbContext;
        }

        public void BeginTransaction()
        {
            _transaction =
                _scmDbContext.Database.CurrentTransaction ?? _scmDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                this.BeginTransaction();

                foreach (var rawCommand in RawSQlCommandList)
                {
                    if (rawCommand.ParamsForSql != null)                    
                        _scmDbContext.Database.ExecuteSqlRaw(rawCommand.RawSqlString, rawCommand.ParamsForSql);
                    
                    else                   
                        _scmDbContext.Database.ExecuteSqlRaw(rawCommand.RawSqlString);
                    
                }

                _scmDbContext.SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                this.Rollback();
            }
            finally
            {
                this.RawSQlCommandList = new List<RawSQlCommand>();
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void AddRawCommand(RawSQlCommand rawSQlCommand) =>
            RawSQlCommandList.Add(rawSQlCommand);
    }
}