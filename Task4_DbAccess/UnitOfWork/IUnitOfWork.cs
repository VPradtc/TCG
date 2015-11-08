using System;

namespace Task4_DbAccess.UnitOfWork
{
    /// <summary>
    /// Defines a unit of work that allows the in-memory changes to be committed to a permanent storage.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
