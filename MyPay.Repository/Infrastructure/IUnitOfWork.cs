using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPay.Repository.Repositories.Inter;

namespace MyPay.Repository.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IUserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
