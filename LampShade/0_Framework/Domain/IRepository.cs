using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey, T> where T : class   //TKEY تایپ آیدیهامونه  ---- T تایپ ENTITY هامونه
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        bool Exist(Expression<Func<T,bool>> expression);
        void SaveChange();



    }
}