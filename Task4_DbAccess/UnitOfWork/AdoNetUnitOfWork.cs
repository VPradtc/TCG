using System;
using System.Data;

namespace Task4_DbAccess.UnitOfWork
{
    /// <summary>
    /// Represents a unit of work that wraps an SQL Server Transaction.
    /// </summary>
    public sealed class AdoNetUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The transaction that is to be sent to the server.
        /// </summary>
        private IDbTransaction m_transaction;
        public IDbTransaction Transaction { get { return m_transaction; } }
        /// <summary>
        /// An action that will be invoked in case the transaction gets rolled back.
        /// </summary>
        private readonly Action<AdoNetUnitOfWork> m_rolledBackCallback;
        /// <summary>
        /// An action that will be invoked in case the transaction gets committed.
        /// </summary>
        private readonly Action<AdoNetUnitOfWork> m_committedCallback;
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rolledBackCallback"></param>
        /// <param name="committedCallback"></param>
        public AdoNetUnitOfWork(IDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBackCallback, Action<AdoNetUnitOfWork> committedCallback)
        {
            m_transaction = transaction;
            m_rolledBackCallback = rolledBackCallback;
            m_committedCallback = committedCallback;
        }
        /// <summary>
        /// Rolls back a transaction if it hasn't been finished yet and get it disposed.
        /// </summary>
        public void Dispose()
        {
            if (m_transaction == null)
                return;

            m_transaction.Rollback();
            m_transaction.Dispose();
            m_rolledBackCallback(this);
            m_transaction = null;
        }
        /// <summary>
        /// Commits a transaction.
        /// </summary>
        public void SaveChanges()
        {
            if (m_transaction == null)
                throw new InvalidOperationException("May not call save changes twice.");

            m_transaction.Commit();
            m_committedCallback(this);
            m_transaction = null;
        }
    }
}
