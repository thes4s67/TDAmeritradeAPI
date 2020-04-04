using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAmeritradeAPI.WebExample.Models;

namespace TDAmeritradeAPI.WebExample.Data.IRepository
{
    public interface IAccessTokenRepository : IRepository<TDAccessToken>
    {
        void Update(TDAccessToken accessToken);
    }
}
