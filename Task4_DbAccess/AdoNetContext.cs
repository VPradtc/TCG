using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Task4_DbAccess.UnitOfWork;

namespace Task4_DbAccess
{
    /// <summary>
    ///  Represents a combination of the Unit Of Work and Repository patterns
    ///  in order to group together changes that will then be written back to the store.
    /// </summary>
    public class AdoNetContext : IDisposable
    {
        /// <summary>
        /// The database connection object.
        /// </summary>
        private readonly IDbConnection m_connection;
        /// <summary>
        /// A factory capable of producing connection objects.
        /// </summary>
        private readonly IConnectionFactory m_connectionFactory;
        /// <summary>
        /// A lock that allows the support of transactions.
        /// </summary>
        private readonly ReaderWriterLockSlim m_rwLock = new ReaderWriterLockSlim();
        /// <summary>
        /// A collection of units of work scheduled for execution.
        /// </summary>
        private readonly LinkedList<AdoNetUnitOfWork> m_uows = new LinkedList<AdoNetUnitOfWork>();
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="connectionFactory">A factory that will create a valid database connection string.</param>
        public AdoNetContext(IConnectionFactory connectionFactory)
        {
            m_connectionFactory = connectionFactory;
            m_connection = m_connectionFactory.Create();
            SqlDependency.Start(m_connection.ConnectionString);
        }

        #region IDisposable implementation

        private bool m_disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                SqlDependency.Stop(m_connection.ConnectionString);
                m_connection.Dispose();
                m_disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~AdoNetContext()
        {
            Dispose(false);
        }

        #endregion

        /// <summary>
        /// Creates a new unit of work and adds it to the queue.
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork CreateUnitOfWork()
        {
            var transaction = m_connection.BeginTransaction();
            var uow = new AdoNetUnitOfWork(transaction, RemoveTransaction, RemoveTransaction);

            m_rwLock.EnterWriteLock();
            m_uows.AddLast(uow);
            m_rwLock.ExitWriteLock();

            return uow;
        }
        /// <summary>
        /// Creates a command and attaches it to the first unit of work in the queue.
        /// </summary>
        /// <returns></returns>
        public virtual IDbCommand CreateCommand()
        {
            var cmd = m_connection.CreateCommand();
            m_rwLock.EnterReadLock();
            if (m_uows.Count > 0)
                cmd.Transaction = m_uows.First.Value.Transaction;
            m_rwLock.ExitReadLock();

            return cmd;
        }
        /// <summary>
        /// Removes a specified unit of work from the execution queue.
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveTransaction(AdoNetUnitOfWork obj)
        {
            m_rwLock.EnterWriteLock();
            m_uows.Remove(obj);
            m_rwLock.ExitWriteLock();
        }

    }
}
