using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Infrastructure
{
    //public interface ICacheRepository<T> where T : class
    //{
    //    IEnumerable<T> GetAll(string SourceCache);
    //    void Add(T entity, string SourceCache);
    //}

    public  class CacheRepository<T>  : IRepository<T>
        where T : class
    {
        ObjectCache cache;
        CacheItemPolicy cachePolicy;

        public CacheRepository()
        {
            cache = MemoryCache.Default;
            cachePolicy = new CacheItemPolicy();
            cachePolicy.SlidingExpiration = new TimeSpan(1, 0, 0);
        }
        //public IEnumerable<T> GetAll(string SourceCache)
        //{
        //    IEnumerable<T> query = null;

        //    if (cache.Contains(SourceCache))
        //    {
        //        var value = cache.Get(SourceCache);
        //        query = (IEnumerable<T>)value;
        //    }
        //    return query;
        //}

       
        public IQueryable<T> All(string SourceCache)
        {
            IQueryable<T> query = null;

            if (cache.Contains(SourceCache))
            {
                var value = cache.Get(SourceCache);
                query = (IQueryable<T>)value;
            }
            return query;
        }

        public void Add(T entity, string SourceCache = "")
        {
            List<T> ObjList;

            if (cache.Contains(SourceCache))
            {
                var value = cache.Get(SourceCache);
                ObjList = (List<T>)value;
                ObjList.Add(entity);
                cache.Remove(SourceCache);
            }
            else
            {
                ObjList = new List<T>();
                ObjList.Add(entity);
            }
            cache.Add(SourceCache, ObjList, cachePolicy);
        }

        public void Delete(T entity, string SourceCache = "")
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity, string SourceCache = "")
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
