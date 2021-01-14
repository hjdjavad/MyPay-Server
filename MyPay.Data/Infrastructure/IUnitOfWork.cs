using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPay.Data.Repositories.Repo;

namespace MyPay.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        UserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
