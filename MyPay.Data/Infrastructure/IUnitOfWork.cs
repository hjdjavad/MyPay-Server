using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyPay.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext
    {
        void Save();
        Task<int> SaveAsync();
    }
}
