using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAmeritradeAPI.WebExample.Data.IRepository;

namespace TDAmeritradeAPI.WebExample.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
            AccessToken = new AccessTokenRepository(_dbContext);
        }
        public IAccessTokenRepository AccessToken { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
