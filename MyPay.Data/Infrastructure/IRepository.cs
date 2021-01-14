using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyPay.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //----------------------------------------------------------------------------------
        /*سه عمل اصلی*/
        //----------------------------------------------------------------------------------
        //اضافه کردن
        void Insert(TEntity entity);
        //ویرایش
        void Update(TEntity entity);
        //حذف بر اساس کلید اصلی
        void Delete(object id);
        //حذف بر اساس شخص یا TEntity
        void Delete(TEntity entity);
        //حذف بر اساس شرط
        void Delete(Expression<Func<TEntity, bool>> wExpression);
        //----------------------------------------------------------------------------------
        /*درخواست ها*/
        //----------------------------------------------------------------------------------
        //در خواست بر اساس کلید اصلی
        TEntity GetById(object id);
        //درخواست برای دریافت همه
        IEnumerable<TEntity> GetAll();
        //درخواست برای دریافت با شرط
        TEntity Get(Expression<Func<TEntity, bool>> wExpression);
        //درخواست برای دریافت شرطی
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> wExpression);
        //----------------------------------------------------------------------------------
        /*ASYNC ها*/
        //----------------------------------------------------------------------------------
        //اضافه کردن
        Task InsertAsync(TEntity entity);
        //در خواست بر اساس کلید اصلی
        Task<TEntity> GetByIdAsync(object id);
        //درخواست برای دریافت همه
        Task<IEnumerable<TEntity>> GetAllAsync();
        //درخواست برای دریافت با شرط
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> wExpression);
        //درخواست برای دریافت شرطی
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> wExpression);
    }
}
