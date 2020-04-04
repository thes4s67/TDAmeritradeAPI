using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TDAmeritradeAPI.WebExample.Data.IRepository;
using TDAmeritradeAPI.WebExample.Models;

namespace TDAmeritradeAPI.WebExample.Data.Repository
{
    public class AccessTokenRepository : Repository<TDAccessToken>, IAccessTokenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AccessTokenRepository(ApplicationDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public void Update(TDAccessToken accessToken)
        {
            var objFromDb = _dbContext.AccessToken.FirstOrDefault(c => c.Id == accessToken.Id);
            if (objFromDb != null)
            {
                objFromDb.access_token = accessToken.access_token;
                objFromDb.refresh_token = accessToken.refresh_token;
                objFromDb.token_type = accessToken.token_type;
                objFromDb.expires_in = accessToken.expires_in;
                objFromDb.scope = accessToken.scope;
                objFromDb.refresh_token_expires_in = accessToken.refresh_token_expires_in;
            }
            _dbContext.SaveChanges();
        }
    }
}
