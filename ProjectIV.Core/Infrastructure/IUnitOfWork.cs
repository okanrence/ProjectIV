using System;

namespace ProjectIV.Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _Context = new AppDBContext();
        internal AppDBContext Context { get { return this._Context; } }

        public int SaveChanges()
        {
            return this._Context.SaveChanges();
        }

        public void Dispose()
        {
            this._Context.Dispose();
        }
    }
}
