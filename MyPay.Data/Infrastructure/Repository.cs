using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyPay.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Ctor
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _dbset;
        public Repository(DbContext db)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }
        #endregion


        #region Normal
        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity is Null");
            _dbset.Update(entity);
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentException("Entity is Null");
            _dbset.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> wExpression)
        {
            IEnumerable<TEntity> objs = _dbset.Where(wExpression).AsEnumerable();
            foreach (TEntity item in objs)
            {
                _dbset.Remove(item);
            }
        }

        public TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> wExpression)
        {
            return _dbset.Where(wExpression).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> wExpression)
        {
            return _dbset.Where(wExpression).AsEnumerable();
        }
        #endregion


        #region Async
        public async Task InsertAsync(TEntity entity)
        {
           await _dbset.AddAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> wExpression)
        {
            return await _dbset.Where(wExpression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> wExpression)
        {
            return await _dbset.Where(wExpression).ToListAsync();
        }
        #endregion


        #region Dispose
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
        ~Repository()
        {
            Dispose(false);
        }
        #endregion
    }
}
