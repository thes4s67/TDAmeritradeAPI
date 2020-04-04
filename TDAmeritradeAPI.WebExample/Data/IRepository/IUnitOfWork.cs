using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDAmeritradeAPI.WebExample.Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccessTokenRepository AccessToken { get; }
        void Save();
    }
}
