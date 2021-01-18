using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPay.Data.Repositories.Inter;
using MyPay.Data.Repositories.Repo;

namespace MyPay.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IUserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
