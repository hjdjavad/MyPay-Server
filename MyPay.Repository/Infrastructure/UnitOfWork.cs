using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPay.Repository.Repositories.Inter;
using MyPay.Repository.Repositories.Repo;

namespace MyPay.Repository.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext:DbContext, new()
    {
        #region ctor
        private readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }
        #endregion


        #region PrivateRepository
        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                return _userRepository;
            }
        }
        #endregion


        #region Save
        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }
        #endregion


        #region dispose
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
